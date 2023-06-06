﻿using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.Localization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Authorization.Users;
using ZooThree.Domain;
using ZooThree.Service.Dto;

namespace ZooThree.Service.PersonService
{
    public class PersonAppService: ApplicationService, IPersonAppService
    {
        private readonly IRepository<Person, Guid> _personRepsitory;
        private readonly UserManager _userManager;
        private ILocalizationManager _localizationManager;

        /// <summary>
        /// 
        /// </summary>

        public PersonAppService(IRepository<Person, Guid> personRepsitory, UserManager userManager, ILocalizationManager localizationManager)
        {
            _personRepsitory = personRepsitory;
            _userManager = userManager;
            _localizationManager = localizationManager;
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<PersonDto> CreateAsync(PersonDto input)
        {
            return ObjectMapper.Map<PersonDto>(await _personRepsitory.InsertAsync(ObjectMapper.Map<Person>(input)));
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task DeleteAsync(Guid id)
        {
            await _personRepsitory.DeleteAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<List<PersonDto>> GetAllAsync()
        {
            var people = await _personRepsitory.GetAllListAsync();
            return ObjectMapper.Map<List<PersonDto>>(people);
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<PersonDto> GetAsync(Guid id)
        {
             return ObjectMapper.Map<PersonDto>(await _personRepsitory.GetAsync(id));
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<PersonDto> UpdateAsync(PersonDto input)
        {
            var person = _personRepsitory.Get(input.Id);
            var updt = await _personRepsitory.UpdateAsync(ObjectMapper.Map(input, person));
            return ObjectMapper.Map<PersonDto>(updt);
        }

        private async Task<User> CreateUser(PersonDto input)
        {
            var user = ObjectMapper.Map<User>(input);
            ObjectMapper.Map(input, user);

            if (!string.IsNullOrEmpty(user.NormalizedUserName) && !string.IsNullOrEmpty(user.NormalizedEmailAddress))
                user.SetNormalizedNames();
            user.TenantId = AbpSession.TenantId;
            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);
            CheckErrors(await _userManager.CreateAsync(user, input.Password));

            CurrentUnitOfWork.SaveChanges();
            return user;
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(_localizationManager);
        }
    }
}
