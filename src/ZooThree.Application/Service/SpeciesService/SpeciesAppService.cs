using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Domain;
using ZooThree.Service.Dto;
using ZooThree.Service.Dto.CustomCreateDto;
using ZooThree.Service.EnclosureService;

namespace ZooThree.Service.SpeciesService
{
    public class SpeciesAppService : ApplicationService, ISpeciesAppService
    {
        private readonly IRepository<Species, Guid> _speciesRepository;
        private readonly IEnclosureAppService _enclosureAppService;

        public SpeciesAppService(IRepository<Species, Guid> speciesRepository, IEnclosureAppService enclosureAppService)
        {

            _speciesRepository = speciesRepository;
            _enclosureAppService = enclosureAppService;
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<SpeciesDto> CreateSpeciesAsync(CreateSpeciesDto input)
        {
           /* var species = ObjectMapper.Map<Species>(input);
            species.EnclosureId = input.Enclosure.Id;

            var createdSpecies = await _speciesRepository.InsertAsync(species);
            return ObjectMapper.Map<SpeciesDto>(createdSpecies);*/

            var species = await _enclosureAppService.GetEnclosureByName(input.EnclosureName) ?? throw new Exception("Species not found");

            var specie = new Species
            {
                SpeciesName = input.SpeciesName,
                EnclosureName = input.EnclosureName,
                EnclosureId = species.Id,
                NumberAlive = input.NumberAlive,
                NumberBirth =  input.NumberBirth,
                NumberDead  = input.NumberDead,


             /*   AnimalName = input.AnimalName,
                SpeciesId = species.Id,
                Age = input.Age*/
            };

            var createdSpecies = await _speciesRepository.InsertAsync(specie);
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



        public async Task<SpeciesDto> GetSpeciesByName(string speciesName)
        {
            var species = await _speciesRepository.FirstOrDefaultAsync(s => s.SpeciesName.ToLower() == speciesName.ToLower());
            return ObjectMapper.Map<SpeciesDto>(species);
        }


    }
}