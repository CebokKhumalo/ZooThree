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
        Task<PersonDto> UpdateAsync(PersonDto input);

        ///<summary>
        ///
        /// </summary>
        Task DeleteAsync(Guid id);
    }
}
