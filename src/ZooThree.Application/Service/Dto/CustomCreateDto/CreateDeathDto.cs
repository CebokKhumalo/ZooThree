using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooThree.Service.Dto.CustomCreateDto
{
    public class CreateDeathDto: EntityDto<Guid>
    {
        public string AnimalName { get; set; }
        public string CauseOfDeath { get; set; }
    }
}
