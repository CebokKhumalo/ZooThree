using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Domain;
using ZooThree.Service.Dto.CustomCreateDto;

namespace ZooThree.Service.BirthServices
{
    public interface IBirthAppService : IApplicationService
    {
        Task<BirthDto> CreateBirthAsync(CreateBirthDto input);

        Task<BirthDto> GetBirthAsync(Guid id);

        Task<List<BirthDto>> GetAllBirthsAsync();

        Task<BirthDto> UpdateBirthAsync(BirthDto input);

        Task DeleteBirthAsync(Guid id);
    }
}
