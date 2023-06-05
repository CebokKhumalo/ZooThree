using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ZooThree.Controllers
{
    public abstract class ZooThreeControllerBase: AbpController
    {
        protected ZooThreeControllerBase()
        {
            LocalizationSourceName = ZooThreeConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
