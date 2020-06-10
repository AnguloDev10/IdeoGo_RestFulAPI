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
    public class RequierementRepository : BaseRepository, IRequierementRepository
    {
        public RequierementRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Requierement requierement)
        {
            await _context.Requierements.AddAsync(requierement);
        }

        public async Task<Requierement> FindByIdAsync(int id)
        {
            return await _context.Requierements.FindAsync(id);
        }

        public async Task<IEnumerable<Requierement>> ListAsync()
        {
            return await _context.Requierements.ToListAsync();
        }

        public void Remove(Requierement requierement)
        {
            _context.Requierements.Remove(requierement);
        }

        public void Update(Requierement requierement)
        {
            _context.Requierements.Update(requierement);
        }
    }
}
