using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooThree.Service.Dto
{

    public class DeathDto : EntityDto<Guid>
    {
        public AnimalDto AnimalId { get; set; }
        public string AnimalName { get; set; }
        public  string CauseOfDeath { get; set; }
    }
}
