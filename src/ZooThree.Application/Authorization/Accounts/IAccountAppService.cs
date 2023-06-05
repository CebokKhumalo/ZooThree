using System.Threading.Tasks;
using Abp.Application.Services;
using ZooThree.Authorization.Accounts.Dto;

namespace ZooThree.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
