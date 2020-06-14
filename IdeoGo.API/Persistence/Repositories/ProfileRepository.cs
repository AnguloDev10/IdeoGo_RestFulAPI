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
    public class ProfileRepository : BaseRepository, IProfileRepository
    {
        public ProfileRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Profile profile)
        {
            await _context.Profiles.AddAsync(profile);
        }

        public async Task<Profile> FindById(int id)
        {
            return await _context.Profiles.FindAsync(id);
        }

        public async Task<IEnumerable<Profile>> ListAsync()
        {
            return await _context.Profiles.ToListAsync();
        }

        public void Remove(Profile profile)
        {
            _context.Profiles.FindAsync(profile);
        }

        public void Update(Profile profile)
        {
            _context.Profiles.Update(profile);
        }
    }
}
