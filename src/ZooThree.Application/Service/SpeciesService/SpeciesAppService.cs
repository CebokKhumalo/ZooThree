using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
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
        private readonly IRepository<Enclosure, Guid> _enclosureRepository;

        public SpeciesAppService(
            IRepository<Species, Guid> speciesRepository,
            IRepository<Enclosure, Guid> enclosureRepository)  // Add this
        {
            _speciesRepository = speciesRepository;
            _enclosureRepository = enclosureRepository;  // And this
        }
        /// <summary>
        /// 
        /// </summary>
        public async Task<SpeciesDto> CreateSpeciesAsync(SpeciesDto input)
        {
            // Find the enclosure by name
            var enclosure = await _enclosureRepository.FirstOrDefaultAsync(e => e.EnclosureName == input.EnclosureName);

            // If enclosure with the given name doesn't exist, throw an exception or return an error
            if (enclosure == null)
            {
                throw new Exception($"No enclosure found with name {input.EnclosureName}.");
            }

            // Map the DTO to a Species, excluding the EnclosureId
            var species = ObjectMapper.Map<Species>(input);

            // Set the EnclosureId from the fetched enclosure
            species.EnclosureId = enclosure.Id;

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
            var speciesList = await _speciesRepository.GetAll()
                                               .Include(s => s.Enclosure) // You need a using statement for Microsoft.EntityFrameworkCore
                                               .ToListAsync();

            var speciesDtos = ObjectMapper.Map<List<SpeciesDto>>(speciesList);

            return speciesDtos;
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

     

        public async Task<SpeciesDto> GetSpeciesByName(string speciesName)
        {
            var species = await _speciesRepository.FirstOrDefaultAsync(s => s.SpeciesName.ToLower() == speciesName.ToLower());
            return ObjectMapper.Map<SpeciesDto>(species);
        }

     
    }
}
