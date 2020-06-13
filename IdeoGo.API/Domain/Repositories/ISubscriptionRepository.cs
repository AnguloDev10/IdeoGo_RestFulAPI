using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    public interface ISubscriptionRepository
    {
        Task AddAsync(Subscription subscription);
        Task<Subscription> FindByIDAsync(int id);
        void Update(Subscription subscription);
        void Remove(Subscription subscription);
        Task<IEnumerable<Subscription>> ListAsync();
    }
}
