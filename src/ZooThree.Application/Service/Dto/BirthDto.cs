using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooThree.Service.Dto;

namespace ZooThree.Domain
{
    
        [AutoMap(typeof(Birth))]
        public class BirthDto : FullAuditedEntity<Guid>
        {
            public string Name { get; set; }

           // public DateTime DateOfBirth { get; set; }

            public SpeciesDto Species { get; set; }
            public Guid SpeciesId { get; set; }
        }
    }

