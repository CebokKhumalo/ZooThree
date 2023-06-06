using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooThree.Service.Dto
{
    public class AnimalDto:FullAuditedEntity<Guid>
    {
        public string AnimalName { get; set; }
        public SpeciesDto Species { get; set; }
        public int Age { get; set; }
    }
}
