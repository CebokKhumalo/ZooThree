using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Domain;
using ZooThree.Domain.Enum;

namespace ZooThree.Service.Dto
{
    [AutoMap(typeof(Animal))]
    public class AnimalDto : EntityDto<Guid>
    {
        public string AnimalName { get; set; }
        public  RefListGender? Gender { get; set; }
        public  RefListHealthStatus? HealthStatus { get; set; }
        public SpeciesDto Species { get; set; }
        public int Age { get; set; }
    }

}
