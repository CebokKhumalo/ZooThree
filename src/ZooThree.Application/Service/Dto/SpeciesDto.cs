using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooThree.Service.Dto
{
    public class SpeciesDto: FullAuditedEntity<Guid>
    {
        public string SpeciesName { get; set; }
      //  public ZookeepersDto Zookeepers { get; set; }
        public EnclosureDto Enclosure { get; set; }
        public int NumberAlive { get; set; }
        public int NumberDead { get; set; }
        public int NumberBirth { get; set; }
    }
}
