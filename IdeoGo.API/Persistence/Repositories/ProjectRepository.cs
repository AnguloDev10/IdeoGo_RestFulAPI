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
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        ProjectRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
        }

        public async Task<Project> FindByIDAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<IEnumerable<Project>> ListAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public void Remove(Project project)
        {
            _context.Projects.FindAsync(project);
        }

        public void Update(Project project)
        {
            _context.Projects.Update(project);
        }
    }
}
