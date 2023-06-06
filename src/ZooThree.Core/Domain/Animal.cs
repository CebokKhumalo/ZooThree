using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Domain.Enum;

namespace ZooThree.Domain
{
    public class Animal: FullAuditedEntity<Guid>
    {
        public virtual string AnimalName { get; set; }
        public Guid SpeciesId { get; set; }
       public Species Species { get; set; }
        public virtual int Age { get; set; }
    }
}
