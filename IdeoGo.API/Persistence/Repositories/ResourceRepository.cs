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
    public class ResourceRepository : BaseRepository, IResourceRepository
    {
        public ResourceRepository(AppDbContext context) : base(context) { }
        public async Task AddAsync(Resource resource)
        {
            await _context.Resources.AddAsync(resource);
        }

        public async Task<Resource> FindByIdAsync(int id)
        {
            return await _context.Resources.FindAsync(id);
        }

        public async Task<IEnumerable<Resource>> ListAsync()
        {
            return await _context.Resources.ToListAsync();
        }

        public void Remove(Resource resource)
        {
            _context.Resources.Remove(resource);
        }

        public void Update(Resource resource)
        {
            _context.Resources.Update(resource);
        }
    }
}
