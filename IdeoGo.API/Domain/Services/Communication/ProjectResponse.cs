
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services.Communication;

namespace IdeoGo.API.Domain.Services.Communications
{

    public class ProjectResponse : BaseResponse<Project>
    {

        public ProjectResponse(Project project) : base(project)
        {
        }

        public ProjectResponse(string message) : base(message) { }


    }

}
