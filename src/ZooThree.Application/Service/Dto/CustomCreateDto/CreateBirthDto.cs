using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooThree.Service.Dto.CustomCreateDto
{
    public class CreateBirthDto: EntityDto<Guid>
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string SpeciesName { get; set; }
        public Guid SpeciesId { get; set; }
    }
    
}
