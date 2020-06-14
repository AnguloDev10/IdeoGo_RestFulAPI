using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services.Communication
{
    public class ActivityResponse : BaseResponse <Activity>
    {
        public ActivityResponse(Activity activity) : base(activity)
        {
        }

        public ActivityResponse(string message) : base(message) { }
    }
}
