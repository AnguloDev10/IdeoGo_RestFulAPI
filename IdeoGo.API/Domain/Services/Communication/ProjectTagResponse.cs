using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services.Communication;

namespace IdeoGo.API.Domain.Services.Communications
{

    public class ProjectTagResponse : BaseResponse<ProjectTag>
    {

        public ProjectTagResponse(ProjectTag projectTag) : base(projectTag)
        {
        }

        public ProjectTagResponse(string message) : base(message) { }
    }

}
