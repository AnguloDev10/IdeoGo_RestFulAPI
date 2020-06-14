using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Persistence.Contexts;
using IdeoGo.API.Domain.Repositories;
using K4os.Compression.LZ4.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Persistence.Repositories
{
    public class MembershipRepository : BaseRepository, IMembershipRepository
    {
        public MembershipRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Membership membership)
        {
            await _context.Memberships.AddAsync(membership);
        }

        public async Task<Membership> FindByIdAsync(int id)
        {
            return await _context.Memberships.FindAsync(id);
        }

        public async Task<IEnumerable<Membership>> ListAsync()
        {
            return await _context.Memberships.ToListAsync();
        }

        public void Remove(Membership membership)
        {
            _context.Memberships.Remove(membership);
        }

        public void Update(Membership membership)
        {
            _context.Memberships.Update(membership);
        }
    }
}
