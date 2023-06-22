using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Domain;
using ZooThree.Service.Dto;
using ZooThree.Service.Dto.CustomCreateDto;
using ZooThree.Service.Helper;
using ZooThree.Service.Helper.Binder;
using ZooThree.Service.SpeciesService;

namespace ZooThree.Service.AnimalService
{
    /// <summary>
    /// 
    /// </summary>
    public class AnimalAppService : ApplicationService, IAnimalAppService
    {
        private readonly IRepository<Animal, Guid> _animalRepository;
        private readonly ISpeciesAppService _speciesAppService;
        private readonly IMapper _mapper;
        private readonly IRepository<Enclosure, Guid> _enclosureRepository;

        public AnimalAppService(IRepository<Animal, Guid> animalRepository, IMapper mapper, ISpeciesAppService speciesAppService, IRepository<Enclosure, Guid> enclosureRepository)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
            _speciesAppService = speciesAppService;
            _enclosureRepository = enclosureRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<AnimalDto> CreateAsync( [ModelBinder(typeof(StringToEnumBinder))] CreateSpeciesDto input)
        {
            var speciesDto = await _speciesAppService.GetSpeciesByName(input.SpeciesName) ?? throw new Exception("Species not found");

            var animal = new Animal
            {
                AnimalName = input.AnimalName,
                //SpeciesId = speciesDto.,
                Age = input.Age,
                Gender = input.Gender,
                HealthStatus = input.HealthStatus

            };

            var createdAnimal = await _animalRepository.InsertAsync(animal);

            // Retrieve the actual Species object from the repository
            var species = await _speciesAppService.GetSpeciesAsync(speciesDto.Id);

            // Update the NumberAlive property of the corresponding Species
            species.NumberAlive++;

            // Save the changes to the Species
            await _speciesAppService.UpdateSpeciesAsync(species);

            // Retrieve the actual Enclosure object from the repository
            var enclosure = await _enclosureRepository.GetAsync(species.EnclosureId);

            // Increase the current capacity of the enclosure
            enclosure.CurrentCapacity++;

            if(enclosure.CurrentCapacity >= enclosure.MaxCapacity)
            {
                throw new Exception("The enclosure is full. No new animal can be created.");
            }

            // Save the changes to the Enclosure
            await _enclosureRepository.UpdateAsync(enclosure);

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
            var animals = await _animalRepository.GetAllIncluding(a => a.Species).ToListAsync();
            return ObjectMapper.Map<List<AnimalDto>>(animals);
        }

            /// <summary>
            /// 
            /// </summary>
            public async Task<AnimalDto> GetAsync(Guid id)
            {
                var entity = await _animalRepository.GetAsync(id);
                var animal = ObjectMapper.Map<AnimalDto>(entity);
                //animal.Species = ObjectMapper.Map<SpeciesDto>(entity.Species);

                return animal;
            }


        public async Task<SpeciesDto> GetSpeciesAsync(Guid animals)
        {
            var entity = await _animalRepository.GetAsync(animals);
            var speciesDto = ObjectMapper.Map<SpeciesDto>(entity);
            speciesDto.SpeciesName = entity.AnimalName;

            return speciesDto;
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<AnimalDto> UpdateAsync(AnimalDto input)
        {
           /* if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }*/

            var animal = await _animalRepository.GetAsync(input.Id);

           /* if (animal == null)
            {
                throw new Exception($"No animal found with the id {input.Id}"); // Replace with your specific exception handling strategy
            }*/

            _mapper.Map(input, animal);

            return _mapper.Map<AnimalDto>(animal);
        }


        /*  Task<AnimalDto> IAnimalAppService.CreateAsync(CreateSpeciesDto input)
          {
              throw new NotImplementedException();
          }*/
    }
} 

