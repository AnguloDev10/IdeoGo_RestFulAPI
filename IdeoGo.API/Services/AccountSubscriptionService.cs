using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Services
{
    public class AccountSubscriptionService : IAccountSubscriptionService
    {
        private readonly IAccountSubscriptionRepository _accountSubscriptionRepository;

        public AccountSubscriptionService(IAccountSubscriptionRepository accountSubscriptionRepository)
        {
            _accountSubscriptionRepository = accountSubscriptionRepository;
        }
        public async Task<IEnumerable<AccountSubscription>> ListAsync()
        {
            return await _accountSubscriptionRepository.ListAsync();
        }
    }
}
