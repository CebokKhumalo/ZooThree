using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Domain;
using ZooThree.Service.Dto;
using ZooThree.Service.Dto.CustomCreateDto;
using ZooThree.Service.SpeciesService;

namespace ZooThree.Service.AnimalService
{
    /// <summary>
    /// 
    /// </summary>
    public class AnimalAppService: ApplicationService, IAnimalAppService
    {
        private readonly IRepository<Animal,Guid> _animalRepository;
        private readonly ISpeciesAppService _speciesAppService;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        public AnimalAppService(IRepository<Animal, Guid> animalRepository, IMapper mapper, ISpeciesAppService speciesAppService)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
            _speciesAppService = speciesAppService;
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<AnimalDto> CreateAsync(CreateSpeciesDto input)
        {
            /*var animal = ObjectMapper.Map<Animal>(input);
              /*    var species  = 
                    animal.SpeciesId =
              var createdAnimal = await _animalRepository.InsertAsync(animal);
              return ObjectMapper.Map<CreateSpeciesDto>(createdAnimal);*/

            var species = await _speciesAppService.GetSpeciesByName(input.SpeciesName) ?? throw new Exception("Species not found");
          
            var animal = new Animal
            {
                AnimalName = input.AnimalName,
                SpeciesId = species.Id,
                Age = input.Age
            };

            var createdAnimal = await _animalRepository.InsertAsync(animal);
            return ObjectMapper.Map<AnimalDto>(createdAnimal);

        }

        /// <summary>
        /// 
        /// </summary>
        public async Task Delete(Guid id)
        { 
            await _animalRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<List<AnimalDto>> GetAllAsync()
        {
            return ObjectMapper.Map<List<AnimalDto>>(await _animalRepository.GetAllListAsync());
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<AnimalDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<AnimalDto>(await _animalRepository.GetAsync(id));
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<AnimalDto> UpdateAsync(AnimalDto input)
        {
            var animal = await _animalRepository.GetAsync(input.Id);
            _mapper.Map(input, animal);
           // animal.SpeciesId = _mapper.Map<SpeciesDto>(input.Species.Id);

            return _mapper.Map<AnimalDto>(animal);
        }

      /*  Task<AnimalDto> IAnimalAppService.CreateAsync(CreateSpeciesDto input)
        {
            throw new NotImplementedException();
        }*/
    }
}
