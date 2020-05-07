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
    public class CollaboratorRespository : BaseRepository, ICollaboratorRepository
    {

        public CollaboratorRespository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Collaborator collaborator)
        {
            await _context.Collaborators.AddAsync(collaborator);
        }

        public async Task<IEnumerable<Collaborator>> ListAsync()
        {
            return await _context.Collaborators.ToListAsync();
        }
    }
}
