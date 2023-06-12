using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Domain;
using ZooThree.Service.AnimalService;
using ZooThree.Service.Dto;
using ZooThree.Service.Dto.CustomCreateDto;

namespace ZooThree.Service.DeathService
{
    public class DeathAppService: ApplicationService, IDeathAppService
    {
        private readonly IRepository<Death, Guid> _deathRepository;
        private readonly IAnimalAppService _animalAppService;

        public DeathAppService(IRepository<Death, Guid> deathRepository, IAnimalAppService animalAppService)
        {
            _deathRepository = deathRepository;
            _animalAppService= animalAppService;
        }

        public async Task<DeathDto> CreateDeathRecordAsync(CreateDeathDto input)
        {
            var deathRecord = await _animalAppService.GetAnimalByName(input.AnimalName) ?? throw new Exception("animal not found");

            var newDeath = new Death
            {
                AnimalId = deathRecord.Id,
                //AnimalName = deathRecord.AnimalName,
                CauseOfDeath = input.CauseOfDeath,
            };

            var createdDeathRecord = await _deathRepository.InsertAsync(newDeath);
            return ObjectMapper.Map<DeathDto>(createdDeathRecord);
        }

        public Task DeleteDeathRecord(Guid id)
        {
           return _deathRepository.DeleteAsync(id);
        }

        public async Task<List<DeathDto>> GetAllDeathRecordAsync()
        {
           return ObjectMapper.Map<List<DeathDto>>(await _deathRepository.GetAllListAsync());
        }

        public async Task<DeathDto> GetDeathRecordAsync(Guid id)
        {
            return ObjectMapper.Map<DeathDto>(await _deathRepository.GetAsync(id));
        }

       public async Task<DeathDto> UpdateDeathRecordAsync(DeathDto input)
        {
            var deathRecord = await _deathRepository.GetAsync(input.Id);
            ObjectMapper.Map(deathRecord, input);
            return ObjectMapper.Map<DeathDto>(deathRecord);
        }
    }
}
