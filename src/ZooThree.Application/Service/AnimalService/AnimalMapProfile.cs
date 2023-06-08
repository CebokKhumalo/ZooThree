using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Domain;
using ZooThree.Service.Dto;
using ZooThree.Service.Dto.CustomCreateDto;

namespace ZooThree.Service.AnimalService
{
    public class AnimalMapProfile: Profile
    {
        public AnimalMapProfile()   
        {
            CreateMap<SpeciesDto, CreateSpeciesDto>()
                .ForMember(x=>x.SpeciesName, m=> m.MapFrom(x => x.SpeciesName));

            CreateMap<CreateSpeciesDto, SpeciesDto>()
                .ForMember(e => e.SpeciesName, d => d.Ignore());


        }

    }
}
