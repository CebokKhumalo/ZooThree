using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooThree.Domain
{
    public class Death: FullAuditedEntity<Guid>
    {
        public Guid AnimalId { get; set; }
        //public string AnimalName { get; set; }
        public virtual string CauseOfDeath { get; set;}
    }
}
