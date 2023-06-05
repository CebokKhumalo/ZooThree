using System.Threading.Tasks;
using ZooThree.Configuration.Dto;

namespace ZooThree.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
