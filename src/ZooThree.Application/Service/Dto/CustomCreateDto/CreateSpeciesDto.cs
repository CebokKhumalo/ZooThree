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
    public class CreateSpeciesDto : EntityDto<Guid>
    {

        public string AnimalName { get; set; }
        public Guid SpeciesId { get; set; }
        public int Age { get; set; }
    }
}
