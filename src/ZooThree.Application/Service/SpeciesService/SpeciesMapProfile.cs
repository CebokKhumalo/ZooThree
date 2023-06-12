using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Service.Dto;
using ZooThree.Service.Dto.CustomCreateDto;

namespace ZooThree.Service.SpeciesService
{
    public class SpeciesMapProfile: Profile
    {
        public SpeciesMapProfile()
        {
            CreateMap<EnclosureDto, CreateSpeciesDto>()
                .ForMember(x => x.EnclosureName, m => m.MapFrom(x => x.EnclosureName));

            CreateMap<CreateSpeciesDto, EnclosureDto>()
               .ForMember(x => x.EnclosureName, d => d.Ignore());
        }

    }
}
