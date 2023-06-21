using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Domain;

namespace ZooThree.Service.Dto
{
    [AutoMap(typeof(Species))]
    public class SpeciesDto: FullAuditedEntity<Guid>
    {
        public string SpeciesName { get; set; }

        //public EnclosureDto Enclosure { get; set; }
        public virtual string EnclosureName { get; set; }
        public int NumberAlive { get; set; }
        public int NumberDead { get; set; }
        public int NumberBirth { get; set; }

        public Guid EnclosureId { get; set; }
        //  public ZookeepersDto Zookeepers { get; set; }
    }
}
