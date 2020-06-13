using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services.Communication
{
    public class SubscriptionResponse : BaseResponse<Subscription>
    {
        public SubscriptionResponse(Subscription subscription) : base(subscription)
        {
        }

        public SubscriptionResponse(string message) : base(message) { }
    }
}
