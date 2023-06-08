using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Service.Dto;

namespace ZooThree.Service.SpeciesService
{
    public interface ISpeciesAppService: IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        Task<SpeciesDto> CreateSpeciesAsync(SpeciesDto input);

        ///<summary>
        ///
        /// </summary>
        Task<SpeciesDto> GetSpeciesAsync(Guid id);

        ///<summary>
        ///
        ///</summary>
        Task<List<SpeciesDto>> GetAllSpeciesAsync();

        /// <summary>
        /// 
        /// </summary>
        Task<SpeciesDto> UpdateSpeciesAsync(SpeciesDto input);

        ///<summary>
        ///
        /// </summary>
        Task DeleteSpeciesAsync(Guid id);


        Task<SpeciesDto> GetSpeciesByName(string speciesName);
    }
}
