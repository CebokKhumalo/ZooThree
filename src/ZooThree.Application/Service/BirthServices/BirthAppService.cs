using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Domain;
using ZooThree.Service.AnimalService;
using ZooThree.Service.Dto.CustomCreateDto;
using ZooThree.Service.SpeciesService;

namespace ZooThree.Service.BirthServices
{
    public class BirthAppService : ApplicationService, IBirthAppService
    {
        private readonly IRepository<BirthDto, Guid> _birthRepository;
        private readonly IAnimalAppService _animalAppService;
        private readonly ISpeciesAppService _speciesAppService;

        public BirthAppService(IRepository<BirthDto, Guid> birthRepository, IAnimalAppService animalAppService, ISpeciesAppService speciesAppService)
        {
            _birthRepository = birthRepository;
            _animalAppService = animalAppService;
            _speciesAppService = speciesAppService;
        }

        public async Task<BirthDto> CreateBirthAsync(CreateBirthDto input)
        {

            var speciesDto = await _speciesAppService.GetSpeciesByName(input.SpeciesName) ?? throw new Exception("Species not found");
           
            var newAnimal = new BirthDto
            {
                Name = input.Name,
                //SpeciesName = input.SpeciesName,
               // Age = 0 // Newly born animal
            };

            

            var createdBirth = await _birthRepository.InsertAsync(newAnimal);

            //var birth = ObjectMapper.Map<BirthDto>(input);

            // Automatically create a new animal of the birth's species.


          //  await _animalAppService.CreateAsync(newAnimal);

            return ObjectMapper.Map<BirthDto>(createdBirth);
        }

        public async Task DeleteBirthAsync(Guid id)
        {
            await _birthRepository.DeleteAsync(id);
        }

        public async Task<List<BirthDto>> GetAllBirthsAsync()
        {
            return ObjectMapper.Map<List<BirthDto>>(await _birthRepository.GetAllListAsync());
        }

        public async Task<BirthDto> GetBirthAsync(Guid id)
        {
            return ObjectMapper.Map<BirthDto>(await _birthRepository.GetAsync(id));
        }

        public async Task<BirthDto> UpdateBirthAsync(BirthDto input)
        {
            var birth = await _birthRepository.GetAsync(input.Id);

            ObjectMapper.Map(input, birth);

            return ObjectMapper.Map<BirthDto>(birth);
        }
    }
}
