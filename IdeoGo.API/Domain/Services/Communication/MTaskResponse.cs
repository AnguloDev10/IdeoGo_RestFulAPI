using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services.Communication
{
    public class MTaskResponse : BaseResponse<MTask>
    {
        public MTaskResponse(MTask mTask) : base(mTask)
        {
        }

        public MTaskResponse(string message) : base(message) { }


    }
}
