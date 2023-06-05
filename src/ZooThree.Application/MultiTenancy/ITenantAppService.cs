using Abp.Application.Services;
using ZooThree.MultiTenancy.Dto;

namespace ZooThree.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

