using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services.Communication
{
    public class ApplicationResponse : BaseResponse<Application>
    {
        public ApplicationResponse(Application application) : base(application)
        {
        }

        public ApplicationResponse(string message) : base(message) { }

    }
}
