using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class AccountSubscription
    {
       
        public int AccountId { get; set; }
      
        public int SubscriptionId { get; set; }
     
        public int MembershipId { get; set; }

        public Account Account { get; set; }
        public Memberchip Membership { get; set; }
        public Subscription Subscription { get; set; }

    }
}
