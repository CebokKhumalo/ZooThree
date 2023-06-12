using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Service.Dto.CustomCreateDto;
using ZooThree.Service.Dto;

namespace ZooThree.Service.DeathService
{
    public interface IDeathAppService : IApplicationService
    {
        Task<DeathDto> CreateDeathRecordAsync(CreateDeathDto input);
        Task<DeathDto> GetDeathRecordAsync(Guid id);
        Task<List<DeathDto>> GetAllDeathRecordAsync();
        Task<DeathDto> UpdateDeathRecordAsync(DeathDto input);
        Task DeleteDeathRecord(Guid id);
    }
}
