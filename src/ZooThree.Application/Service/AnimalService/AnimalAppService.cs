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

namespace ZooThree.Service.AnimalService
{
    /// <summary>
    /// 
    /// </summary>
    public class AnimalAppService: ApplicationService, IAnimalAppService
    {
        private readonly IRepository<Animal,Guid> _animalRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        public AnimalAppService(IRepository<Animal, Guid> animalRepository, IMapper mapper)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<CreateSpeciesDto> CreateAsync(CreateSpeciesDto input)
        {
            var animal = ObjectMapper.Map<Animal>(input);
            var createdAnimal = await _animalRepository.InsertAsync(animal);
            return ObjectMapper.Map<CreateSpeciesDto>(createdAnimal);
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
            animal.Species = _mapper.Map<Species>(input.Species);

            return _mapper.Map<AnimalDto>(animal);
        }

      /*  Task<AnimalDto> IAnimalAppService.CreateAsync(CreateSpeciesDto input)
        {
            throw new NotImplementedException();
        }*/
    }
}
