using AutoMapper;
using GoToLearn.Dtos;
using GoToLearn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoToLearn.App_Start
{
    
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                //Domain to Dto
                Mapper.CreateMap<Learner, LearnerDto>();
                Mapper.CreateMap<Training, TrainingDto>();
                Mapper.CreateMap<Trainer, TrainerDto>();
                
                Mapper.CreateMap<MembershipType, MembershipTypeDto>();
                Mapper.CreateMap<Field, FieldDto>();

                //Dto to Domain
                Mapper.CreateMap<LearnerDto, Learner>()
                    .ForMember(l => l.Id, opt => opt.Ignore());
                Mapper.CreateMap<TrainingDto, Training>()
                    .ForMember(t => t.Id, opt => opt.Ignore());
                Mapper.CreateMap<TrainerDto, Trainer>()
                  .ForMember(t => t.Id, opt => opt.Ignore());
                Mapper.CreateMap<FieldDto, Field>()
                 .ForMember(t => t.Id, opt => opt.Ignore());
                Mapper.CreateMap<MembershipTypeDto, MembershipType>()
                 .ForMember(t => t.Id, opt => opt.Ignore());


            }
        }
    }
