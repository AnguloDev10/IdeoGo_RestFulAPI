using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Persistence.Repositories;
using IdeoGo.API.Persistences.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Persistence
{
    public class PublicationRepository : BaseRepository, IPublicationRespository
    {
        public PublicationRepository(AppDbContext context) : base(context) { }
        public async Task AddAsync(Publication publication)
        {
            await _context.Publications.AddAsync(publication);
        }

        public async Task<Publication> FindByIDAsync(int id)
        {
            return await _context.Publications.FindAsync(id);
        }

        public async Task<IEnumerable<Publication>> ListAsync()
        {
            return await _context.Publications.ToListAsync();
        }

        public void Remove(Publication publication)
        {
            _context.Publications.FindAsync(publication);
        }

        public void Update(Publication publication)
        {
            _context.Publications.Update(publication);
        }
    }
}
