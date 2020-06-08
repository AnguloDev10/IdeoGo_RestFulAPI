using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services.Communication
{
    public class TagResponse : BaseResponse<Tag>
    {

        public TagResponse(Tag tag) : base(tag)
        {
        }

        public TagResponse(string message) : base(message) { }


    }
}
