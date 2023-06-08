using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooThree.Service.Dto.CustomCreateDto
{
    public class CreateSpeciesDto: EntityDto<Guid>
    {
        public string SpeciesName { get; set; }

        //public string EnclosureId { get; set; }
        public string EnclosureName { get; set; }
        public int NumberAlive { get; set; }
        public int NumberDead { get; set; }
        public int NumberBirth { get; set; }


        //  public ZookeepersDto Zookeepers { get; set; }

    }
}
