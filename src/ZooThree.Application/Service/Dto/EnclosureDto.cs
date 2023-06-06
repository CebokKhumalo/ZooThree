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
    [AutoMap(typeof(Enclosure))]
    public class EnclosureDto:FullAuditedEntity<Guid>
    {
        public string EnclosureName { get; set; }
        public int CurrentCapacity { get; set; }
        public int MaxCapacity { get; set; }
    }
}
