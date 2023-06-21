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

namespace ZooThree.Service.BirthServices
{
    public class BirthAppService : ApplicationService, IBirthAppService
    {
        private readonly IRepository<BirthDto, Guid> _birthRepository;
        private readonly IAnimalAppService _animalAppService;

        public BirthAppService(IRepository<BirthDto, Guid> birthRepository, IAnimalAppService animalAppService)
        {
            _birthRepository = birthRepository;
            _animalAppService = animalAppService;
        }

        public async Task<BirthDto> CreateBirthAsync(BirthDto input)
        {
            var birth = ObjectMapper.Map<BirthDto>(input);

            var createdBirth = await _birthRepository.InsertAsync(birth);

            // Automatically create a new animal of the birth's species.
            var newAnimal = new CreateSpeciesDto
            {
                AnimalName = input.Name,
                SpeciesName = input.Species.SpeciesName,
                Age = 0 // Newly born animal
            };

            await _animalAppService.CreateAsync(newAnimal);

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
