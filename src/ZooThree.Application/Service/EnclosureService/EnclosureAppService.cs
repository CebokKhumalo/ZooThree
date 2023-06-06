using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Domain;
using ZooThree.Service.Dto;

namespace ZooThree.Service.EnclosureService
{
    public class EnclosureAppService : ApplicationService, IEnclosureAppService
    {
        private readonly IRepository<Enclosure, Guid> _enclosureRepository;

        public EnclosureAppService(IRepository<Enclosure, Guid> enclosureRepository)
        {
            _enclosureRepository = enclosureRepository;
        }    

        public async Task<EnclosureDto> CreateEnclosureAsync(EnclosureDto input)
        {
            return ObjectMapper.Map<EnclosureDto>(await _enclosureRepository.InsertAsync(ObjectMapper.Map<Enclosure>(input)));
        }

        public async Task DeleteEnclosureAsync(Guid id)
        {
            await _enclosureRepository.DeleteAsync(id);
        }

        public async Task<List<EnclosureDto>> GetAllEnclosureAsync()
        {
           return ObjectMapper.Map<List<EnclosureDto>>(await _enclosureRepository.GetAllListAsync());
        }

        public async Task<EnclosureDto> GetEnclosureAsync(Guid id)
        {
            return ObjectMapper.Map<EnclosureDto>(await _enclosureRepository.GetAsync(id));
        }

        public async Task<EnclosureDto> UpdateEnclosureAsync(EnclosureDto input)
        {
            var enclosure = await _enclosureRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, enclosure);
            return ObjectMapper.Map<EnclosureDto>(enclosure);
        }


    }
}
