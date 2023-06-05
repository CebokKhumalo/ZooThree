using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ZooThree.EntityFrameworkCore;
using ZooThree.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ZooThree.Web.Tests
{
    [DependsOn(
        typeof(ZooThreeWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ZooThreeWebTestModule : AbpModule
    {
        public ZooThreeWebTestModule(ZooThreeEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ZooThreeWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ZooThreeWebMvcModule).Assembly);
        }
    }
}