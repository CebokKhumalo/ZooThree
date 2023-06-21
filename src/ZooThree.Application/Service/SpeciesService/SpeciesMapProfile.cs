using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Authorization.Users;
using ZooThree.Domain;
using ZooThree.Service.Dto;

namespace ZooThree.Service.SpeciesService
{
   

    public class SpeciesMapProfile : Profile
    {
        public SpeciesMapProfile()
        {
           CreateMap<SpeciesDto, Species>()
    .ForMember(dest => dest.Enclosure, opt => opt.Ignore());

        }
    }
}
