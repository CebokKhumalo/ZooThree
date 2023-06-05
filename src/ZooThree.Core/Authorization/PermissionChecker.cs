using Abp.Authorization;
using ZooThree.Authorization.Roles;
using ZooThree.Authorization.Users;

namespace ZooThree.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
