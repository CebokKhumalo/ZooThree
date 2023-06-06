using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Domain;
using ZooThree.Service.Dto;

namespace ZooThree.Service.SpeciesService
{
    public class SpeciesAppService: ApplicationService, ISpeciesAppService
    {
        private readonly IRepository<Species, Guid> _speciesRepository;

        public SpeciesAppService(IRepository<Species, Guid> speciesRepository)
        {
           
            _speciesRepository = speciesRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<SpeciesDto> CreateSpeciesAsync(SpeciesDto input)
        {
            var species = ObjectMapper.Map<Species>(input);
            species.EnclosureId = input.Enclosure.Id;

            var createdSpecies = await _speciesRepository.InsertAsync(species);
            return ObjectMapper.Map<SpeciesDto>(createdSpecies);
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task DeleteSpeciesAsync(Guid id)
        {
           await _speciesRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<List<SpeciesDto>> GetAllSpeciesAsync()
        {
            return ObjectMapper.Map<List<SpeciesDto>>(await _speciesRepository.GetAllListAsync());
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<SpeciesDto> GetSpeciesAsync(Guid id)
        {
            return ObjectMapper.Map<SpeciesDto>(await _speciesRepository.GetAsync(id));
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<SpeciesDto> UpdateSpeciesAsync(SpeciesDto input)
        {
            var species = await _speciesRepository.GetAsync(input.Id);

            ObjectMapper.Map(input, species);
            return ObjectMapper.Map<SpeciesDto>(species);
        }
    }
}
