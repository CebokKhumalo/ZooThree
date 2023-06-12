using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Service.Dto;
using ZooThree.Service.Dto.CustomCreateDto;

namespace ZooThree.Service.DeathService
{
    public class DeathMapProfile: Profile
    {
        public DeathMapProfile()
        {
            CreateMap<AnimalDto, CreateDeathDto>()
                .ForMember(x => x.AnimalName, m => m.MapFrom(x => x.AnimalName));

            CreateMap<CreateDeathDto, AnimalDto>()
                .ForMember(x => x.AnimalName, d => d.Ignore());
        }
    }
}
