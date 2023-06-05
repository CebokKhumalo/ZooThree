using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooThree.Domain
{
    public class Enclosure: FullAuditedEntity<Guid>
    {
        public virtual string EnclosureName { get; set; }
        public virtual int CurrentCapacity { get; set; }
        public virtual int MaxCapacity { get; set; }
    }
}
