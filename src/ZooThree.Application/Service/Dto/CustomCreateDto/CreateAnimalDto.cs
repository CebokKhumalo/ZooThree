using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooThree.Service.Dto.CustomCreateDto
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateAnimalDto : EntityDto<Guid>
    {

        public string AnimalName { get; set; }
        public string SpeciesName { get; set; }
        public int Age { get; set; }
    }
}
