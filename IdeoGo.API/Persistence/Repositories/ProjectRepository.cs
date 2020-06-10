using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Persistence.Contexts;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Persistence.Repositories;

namespace IdeoGo.API.Persistence.Repositories
{
    public class ProjectRepository : BaseRepository, IProjectRepository

    {
        public ProjectRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
        }

        public Task<Project> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Project>> ListAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public void Remove(Project project)
        {
            _context.Projects.Remove(project);
        }

        public void Update(Project project)
        {
            _context.Projects.Update(project);
        }
    }
}
