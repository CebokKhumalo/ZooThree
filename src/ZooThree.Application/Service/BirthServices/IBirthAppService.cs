using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Domain;

namespace ZooThree.Service.BirthServices
{
    public interface IBirthAppService : IApplicationService
    {
        Task<BirthDto> CreateBirthAsync(BirthDto input);

        Task<BirthDto> GetBirthAsync(Guid id);

        Task<List<BirthDto>> GetAllBirthsAsync();

        Task<BirthDto> UpdateBirthAsync(BirthDto input);

        Task DeleteBirthAsync(Guid id);
    }
}
