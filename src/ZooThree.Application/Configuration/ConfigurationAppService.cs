using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ZooThree.Configuration.Dto;

namespace ZooThree.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ZooThreeAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
