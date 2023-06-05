using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Authorization.Users;
using ZooThree.Domain;
using ZooThree.Service.Dto;

namespace ZooThree.Service.PersonService.NewFolder
{
    public class PersonMapProfile :Profile
    {
        public PersonMapProfile()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(x => x.Id, m => m.MapFrom(x => x.User != null));

            CreateMap<PersonDto, User>()
              .ForMember(x => x.Name, m => m.MapFrom(x => x.Name))
              .ForMember(x => x.PhoneNumber, m => m.MapFrom(x => x.PhoneNumber))
              .ForMember(x => x.EmailAddress, m => m.MapFrom(x => x.EmailAddress))
              .ForMember(x => x.FullName, m => m.MapFrom(x => x.Name + " " + x.Surname))
              .ForMember(x => x.Surname, m => m.MapFrom(x => x.Surname));

            CreateMap<PersonDto, User>()
                .ForMember(e => e.Id, d => d.Ignore());

            CreateMap<PersonDto, Person>()
                .ForMember(e => e.Id, d => d.Ignore());
        }
    }
}
