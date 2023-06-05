using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooThree.Domain
{
    public class Species:FullAuditedEntity<Guid>
    {
        public virtual string SpeciesName { get; set; }
       // public Zookeeper Zookeepers { get; set; }
        public Enclosure Enclosure { get; set; }
        public virtual int NumberAlive { get; set; }
        public virtual int NumberDead { get; set; }
        public virtual int NumberBirth { get; set; }
    }
}
