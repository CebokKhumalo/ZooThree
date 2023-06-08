using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Service.Dto;

namespace ZooThree.Service.EnclosureService
{
    public interface IEnclosureAppService: IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        Task<EnclosureDto> CreateEnclosureAsync(EnclosureDto input);

        ///<summary>
        ///
        /// </summary>
        Task<EnclosureDto> GetEnclosureAsync(Guid id);

        ///<summary>
        ///
        ///</summary>
        Task<List<EnclosureDto>> GetAllEnclosureAsync();

        /// <summary>
        /// 
        /// </summary>
        Task<EnclosureDto> UpdateEnclosureAsync(EnclosureDto input);

        ///<summary>
        ///
        /// </summary>
        Task DeleteEnclosureAsync(Guid id);


        Task<EnclosureDto> GetEnclosureByName(string EnclosureName);
    }
}
