using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
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

        /// <summary>
        /// 
        /// </summary>

        public PersonAppService(IRepository<Person, Guid> personRepsitory, UserManager userManager)
        {
            _personRepsitory = personRepsitory;
            _userManager = userManager;
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<PersonDto> CreateAsync(PersonDto input)
        {
            var person = ObjectMapper.Map<Person>(input);
            person.User = await CreateUser(input);
            return ObjectMapper.Map<PersonDto>(
                await _personRepsitory.InsertAsync(person));
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
            var query = _personRepsitory.GetAllIncluding(m => m.User).ToList();
            return ObjectMapper.Map<List<PersonDto>>(query);
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<PersonDto> GetAsync(Guid id)
        {
            var query = _personRepsitory.GetAllIncluding(m => m.User).FirstOrDefault(x => x.Id == id);
            return ObjectMapper.Map<PersonDto>(query);
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

            CurrentUnitOfWork.SaveChanges();
            return user;
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
