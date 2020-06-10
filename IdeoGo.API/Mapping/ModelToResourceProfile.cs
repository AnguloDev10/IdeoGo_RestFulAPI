using AutoMapper;
using IdeoGo.API.Domain.Models;
using IdeoGo.API.Extensions;
using IdeoGo.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Mapping
{
    public class ModelToResourceProfile : AutoMapper.Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<User, UserResource>();
            CreateMap<Domain.Models.Profile, ProfileResource>();
            CreateMap<Domain.Models.Profile, ProfileResource>()
               .ForMember(src => src.Gender,
               opt => opt.MapFrom(src => src.Gender.ToDescriptionString()));

            CreateMap<Tag, TagResource>();


            CreateMap<Requierement, RequierementResource>();
            CreateMap<Resource, ResourceResource>();
            CreateMap<Resource, ResourceResource>()
                .ForMember(src => src.UnitOfMeasurement,
                opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));
            
            CreateMap<Skill, SkillResource>();
            CreateMap<Application, ApplicationResource>();

            CreateMap<Project, ProjectResource>();


            CreateMap<ProjectSchedule, ProjectScheduleResource>();
            CreateMap<Goal, GoalResource>();
            CreateMap<Activity, ActivityResource>();
            CreateMap<MTask, MTaskResource > ();
        }
    }
}
