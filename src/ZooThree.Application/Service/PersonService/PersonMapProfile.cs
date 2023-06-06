using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Authorization.Users;
using ZooThree.Domain;
using ZooThree.Service.Dto;

namespace ZooThree.Service.PersonService
{
    public class PersonMapProfile : Profile
    {
        public PersonMapProfile()
        {
            CreateMap<Person, PersonDto>()
               .ForMember(x => x.userId, m => m.MapFrom(x => x.User != null ? x.User.Id : (long?)null));

            CreateMap<PersonDto, User>()
              .ForMember(x => x.Name, m => m.MapFrom(x => x.Name))
              .ForMember(x => x.Password, m => m.MapFrom(x => x.Password))
              .ForMember(x => x.EmailAddress, m => m.MapFrom(x => x.Email))
              .ForMember(x => x.UserName, m => m.MapFrom(m => m.UserName + "2323"));

            CreateMap<PersonDto, User>()
                .ForMember(e => e.Id, d => d.Ignore());

            CreateMap<PersonDto, Person>()
                .ForMember(e => e.Id, d => d.Ignore());
        }
    }
}
