using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.Localization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        public async Task<PersonDto> GetAsyncByEmailAndPassword(string email, string password)
        {
            // Implement your logic to retrieve the person based on the provided email and password
            // For example, you can use the UserManager to find the user by email and validate the password

            // Replace the following code with your actual implementation
            var person = await _personRepsitory.GetAll()
                .FirstOrDefaultAsync(p => p.Email == email && p.Password == password);

            return ObjectMapper.Map<PersonDto>(person);
        }

        public async Task<PersonDto> GetAsyncByUsenameAndPassword(string userName, string password)
        {
            // Implement your logic to retrieve the person based on the provided email and password
            // For example, you can use the UserManager to find the user by email and validate the password

            // Replace the following code with your actual implementation
            var person = await _personRepsitory.GetAll()
                .FirstOrDefaultAsync(p => p.UserName == userName && p.Password == password);

            return ObjectMapper.Map<PersonDto>(person);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<PersonDto> GetAsyncByUsenameOrEmailAndPassword(string userNameOrEmail, string password)
        {
            // Implement your logic to retrieve the person based on the provided email and password
            // For example, you can use the UserManager to find the user by email and validate the password

            // Replace the following code with your actual implementation
            var person = await _personRepsitory.GetAll()
                .FirstOrDefaultAsync(p => p.UserName == userNameOrEmail || p.Email== userNameOrEmail && p.Password == password);

            return ObjectMapper.Map<PersonDto>(person);
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
