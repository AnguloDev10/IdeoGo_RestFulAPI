using IdeoGo.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services.Communication;

namespace IdeoGo.API.Domain.Services.Communications
{
    public class ProjectUserResponse : BaseResponse<ProjectUser>
    {
        public ProjectUserResponse(ProjectUser projectUser) : base(projectUser)
        {
        }

        public ProjectUserResponse(string message) : base(message) { }
    }
}
