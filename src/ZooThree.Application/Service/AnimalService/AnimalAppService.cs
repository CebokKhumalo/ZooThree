using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Domain;
using ZooThree.Service.Dto;

namespace ZooThree.Service.AnimalService
{
    /// <summary>
    /// 
    /// </summary>
    public class AnimalAppService: ApplicationService, IAnimalAppService
    {
        private readonly IRepository<Animal,Guid> _animalRepository;

        /// <summary>
        /// 
        /// </summary>
        public AnimalAppService(IRepository<Animal, Guid> animalRepository)
        {
            _animalRepository = animalRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        public async Task<AnimalDto> CreateAsync(AnimalDto input)
        {
            return ObjectMapper.Map<AnimalDto>(await _animalRepository.InsertAsync(ObjectMapper.Map<Animal>(input)));
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


        public async Task<AnimalDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<AnimalDto>(await _animalRepository.GetAsync(id));
        }

        public async Task<AnimalDto> UpdateAsync(AnimalDto input)
        {
            var animal = await _animalRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, animal);
            return ObjectMapper.Map<AnimalDto>(animal);
        }

        
    }
}
