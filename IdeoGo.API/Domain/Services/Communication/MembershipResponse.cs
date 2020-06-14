using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services.Communication
{
    public class MembershipResponse : BaseResponse<Membership>
    {
        public MembershipResponse(Membership membership) : base(membership)
        {
        }

        public MembershipResponse(string message) : base(message) { }
    }
}
