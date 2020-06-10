using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeoGo.API.Domain.Services.Communication;

namespace IdeoGo.API.Domain.Services.Communication
{
    public class RequierementResponse : BaseResponse<Requierement>
    {
  
            public RequierementResponse(Requierement requierement) : base(requierement)
            {
            }

            public RequierementResponse(string message) : base(message) { }
        

    }
}
