using IdeoGo.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Resources
{
    public class TagResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CategoryResponse Category { get; set; }


    }
}
