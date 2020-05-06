using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    public interface IAccountSubscriptionRepository
    {
        Task<IEnumerable<AccountSubscription>> ListAsync();
        Task AddAsync(int membershipId, int accountId, int subscriptionId);
    }
}
