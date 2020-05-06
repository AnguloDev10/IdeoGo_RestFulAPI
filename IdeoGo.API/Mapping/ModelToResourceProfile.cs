using AutoMapper;
using IdeoGo.API.Domain.Models;
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
            CreateMap<Category, CtegoryResource>();
        }
    }
}
