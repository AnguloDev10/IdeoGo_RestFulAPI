using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services.Communication
{

    public class GoalResponse : BaseResponse<Goal>
    {
        public GoalResponse(Goal goal) : base(goal)
        {
        }

        public GoalResponse(string message) : base(message) { }

    }
}