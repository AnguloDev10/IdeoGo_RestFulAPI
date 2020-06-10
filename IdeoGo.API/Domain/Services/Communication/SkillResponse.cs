using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services.Communication
{
    public class SkillResponse : BaseResponse<Skill>
    {

        public SkillResponse(Skill skill) : base(skill)
        {
        }

        public SkillResponse(string message) : base(message) { }


    }
}
