using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Persistences.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Persistence.Repositories
{

    public class EntrepreneurRepository : BaseRepository, IEntrepreneurRepository
    {
        public EntrepreneurRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Entrepreneur>> ListAsync()
        {
            return await _context.Enterpreneurs.ToListAsync();
        }

        public async Task AddAsync(Entrepreneur entrepreneur)
        {
            await _context.Enterpreneurs.AddAsync(entrepreneur);
        }
        public void Update(Entrepreneur entrepreneur)
        {
            _context.Enterpreneurs.Update(entrepreneur);
        }

        public void Remove(Entrepreneur entrepreneur)
        {
            _context.Enterpreneurs.Remove(entrepreneur);
            
        }

        public Task<Entrepreneur> FindByIDAsync(int id)
        {
            throw new NotImplementedException();
        }
    }


}
