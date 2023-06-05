using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ZooThree.Configuration;

namespace ZooThree.Web.Host.Startup
{
    [DependsOn(
       typeof(ZooThreeWebCoreModule))]
    public class ZooThreeWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ZooThreeWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ZooThreeWebHostModule).GetAssembly());
        }
    }
}
