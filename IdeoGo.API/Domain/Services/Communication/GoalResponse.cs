using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services.Communication
{
    public class GoalResponse : BaseResponse
    {
        public Goal Goal { get; private set; }

        public GoalResponse(bool success, string message, Goal goal) : base(success, message) ///pasa la llamada a el constructor del padre
        {
            Goal = goal;
        }


        public GoalResponse(Goal goal) : this(true, string.Empty, goal)
        {
            //Escenario feliz
        }

        public GoalResponse(string message) : this(false, message, null)
        {
            ///Escenario triste
        }
    }
}