using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooThree.Domain
{
    public class Birth: FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual Species Species { get; set; }
        public virtual Guid SpeciesId { get; set; }

        // public DateTime DateOfBirth { get; set; }


    }
}
