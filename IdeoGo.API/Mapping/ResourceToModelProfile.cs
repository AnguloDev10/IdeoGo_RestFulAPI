using IdeoGo.API.Domain.Models;
using IdeoGo.API.Resources;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Profile = IdeoGo.API.Domain.Models.Profile;

namespace IdeoGo.API.Mapping
{
    public class ResourceToModelProfile : AutoMapper.Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource        , Category                >();
            CreateMap<SaveUserResource            , User                      >();
            CreateMap<SaveProfileResource         , Profile                 >();
            CreateMap<SaveTagResource             , Tag                     >();
            CreateMap<SaveRequierementResource    , Requierement             >();
            CreateMap<SaveResourceResource        , Resource                  >();
            CreateMap<SaveSkillResource           , Skill                     >();
            CreateMap<SaveApplicationResource     , Application                   >();
            CreateMap<SaveProjectResource         , Project                   >();
            CreateMap<SaveProjectScheduleResource , ProjectSchedule               >();
            CreateMap<SaveGoalResource            , Goal                      >();
            CreateMap<SaveActivityResource        , Activity                      >();
            CreateMap< SaveMTaskResource          ,  MTask                    >();
        }
    }
}

