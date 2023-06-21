using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Domain;
using ZooThree.Service.Dto;
using ZooThree.Service.Dto.CustomCreateDto;
using ZooThree.Service.Helper;

namespace ZooThree.Service.AnimalService
{
    public class AnimalMapProfile: Profile
    {
        public AnimalMapProfile()   
        {
            CreateMap<SpeciesDto, CreateSpeciesDto>()
                .ForMember(x=>x.SpeciesName, m=> m.MapFrom(x => x.SpeciesName));

             CreateMap<Animal, AnimalDto>()
                 .ForMember(x => x.Gender, m => m.MapFrom(x => x.Gender != null ? x.Gender.GetEnumDescription() : null))
                 .ForMember(x => x.HealthStatus, m => m.MapFrom(x => x.HealthStatus != null ? x.HealthStatus.GetEnumDescription() : null));

            CreateMap<AnimalDto, Animal>()
                .ForMember(e => e.Gender, d => d.Ignore())
                .ForMember(e => e.HealthStatus, d => d.Ignore());

            CreateMap<CreateSpeciesDto, SpeciesDto>()
                .ForMember(e => e.SpeciesName, d => d.Ignore());


        }

    }
}
