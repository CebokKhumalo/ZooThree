using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Service.Dto;

namespace ZooThree.Service.PersonService
{
    public interface IPersonAppService: IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        Task<PersonDto> CreateAsync(PersonDto input);

        ///<summary>
        ///
        /// </summary>
        Task<PersonDto> GetAsync(Guid id);

        ///<summary>
        ///
        ///</summary>
        Task<List<PersonDto>> GetAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<PersonDto> GetAsyncByEmailAndPassword(string email, string password);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<PersonDto> GetAsyncByUsenameAndPassword(string userName, string password);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userNameOrEmail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<PersonDto> GetAsyncByUsenameOrEmailAndPassword(string userNameOrEmail, string password);

        /// <summary>
        /// 
        /// </summary>
        Task<PersonDto> UpdateAsync(PersonDto input);

        ///<summary>
        ///
        /// </summary>
        Task DeleteAsync(Guid id);
    }
}
