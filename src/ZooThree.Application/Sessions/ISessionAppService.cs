using System.Threading.Tasks;
using Abp.Application.Services;
using ZooThree.Sessions.Dto;

namespace ZooThree.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
