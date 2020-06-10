using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Domain.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Persistence.Repositories
{
    public class ActivityRepository : BaseRepository, IActivityRepository
    {
        public ActivityRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Activity>> ListAsync()
        {

            return await _context.Activities.ToListAsync();
        }

        public async Task AddAsync(Activity activity)
        {
            await _context.Activities.AddAsync(activity);
        }

        public async Task<Activity> FindByIDAsync(int id)
        {
            return await _context.Activities.FindAsync(id);
        }

        public void Update(Activity activity)
        {
            _context.Activities.Update(activity);
        }

        public void Remove(Activity activity)
        {
            _context.Activities.Remove(activity);
        }

    }
}
