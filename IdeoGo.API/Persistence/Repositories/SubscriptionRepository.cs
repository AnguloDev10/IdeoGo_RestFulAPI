using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Persistence.Contexts;
using IdeoGo.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Persistence.Repositories
{
    public class SubscriptionRepository : BaseRepository, ISubscriptionRepository
    {
        public SubscriptionRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Subscription subscription)
        {
            await _context.Subscriptions.AddAsync(subscription);
        }

        public async Task AssigSuscriptionUser(int subId, int userId)
        {
            Subscription susUser = await FindByIDAsync(subId);
            if (susUser == null)
            {
                susUser = new Subscription { Id = subId, UserId = userId };
                await AddAsync(susUser);
            }
        }

        public async Task<Subscription> FindByIDAsync(int id)
        {
            return await _context.Subscriptions.FindAsync(id);
        }

        public async Task<IEnumerable<Subscription>> ListAsync()
        {
            return await _context.Subscriptions.ToListAsync();
        }

        public void Remove(Subscription subscription)
        {
            _context.Subscriptions.Remove(subscription);
        }

        public async void UnassignSuscriptionUserAsync(int subId, int userId)
        {
            Subscription susUser = await FindByIDAsync(subId);
            if (susUser == null)
            {
                Remove(susUser);
            }
        }

        public void Update(Subscription subscription)
        {
            _context.Subscriptions.Update(subscription);
        }
    }
}
