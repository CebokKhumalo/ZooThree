using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Service.Dto.CustomCreateDto;
using ZooThree.Service.Dto;
using ZooThree.Domain;

namespace ZooThree.Service.BirthServices
{
    public class BirthMapServices: Profile
    {
        public BirthMapServices()
        {
            CreateMap<BirthDto, CreateBirthDto>()
               .ForMember(x => x.SpeciesId, m => m.MapFrom(x => x.SpeciesId));


            CreateMap<CreateBirthDto, BirthDto>()
                .ForMember(e => e.SpeciesId, d => d.Ignore());

        }

    }
}
