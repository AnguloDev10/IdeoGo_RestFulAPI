using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeoGo.API.Domain.Persistence.Contexts;

namespace IdeoGo.API.Persistence.Repositories
{
    public class ApplicationRepository : BaseRepository, IApplicationRepository
    {
        public ApplicationRepository(AppDbContext context) : base(context) {}
        public async Task AddAsync(Application application)
        {
           await _context.Aplications.AddAsync(application);
        }
        public async Task<Application> FindByIDAsync(int id)
        {
            return await _context.Aplications.FindAsync(id);
        }

        public async Task<IEnumerable<Application>> ListAsync()
        {
            return await _context.Aplications.ToListAsync();
        }

        public void Remove(Application application)
        {
            _context.Aplications.Remove(application);
        }

        public void Update(Application application)
        {
            _context.Aplications.Update(application);
        }

      
    }
}
