using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services.Communication
{
    public class ProjectScheduleResponse : BaseResponse<ProjectSchedule>
    {

        public ProjectScheduleResponse(ProjectSchedule projectSchedule) : base(projectSchedule)
        {
        }

        public ProjectScheduleResponse(string message) : base(message) { }
    }
}