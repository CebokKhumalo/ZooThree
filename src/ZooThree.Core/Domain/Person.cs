using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Authorization.Users;
using Abp.Domain.Entities.Auditing;
using ZooThree.Domain.Enum;

namespace ZooThree.Domain
{
    public class Person: FullAuditedEntity<Guid>
    {
        public virtual string UserName { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual User User { get; set; }

    }
}
