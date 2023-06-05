using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ZooThree.Authorization;

namespace ZooThree
{
    [DependsOn(
        typeof(ZooThreeCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ZooThreeApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ZooThreeAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ZooThreeApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
