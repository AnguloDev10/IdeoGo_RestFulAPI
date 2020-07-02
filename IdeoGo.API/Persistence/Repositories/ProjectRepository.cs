using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Persistence.Contexts;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Persistence.Repositories;
using FluentAssertions;

namespace IdeoGo.API.Persistence.Repositories
{
    public class ProjectRepository : BaseRepository, IProjectRepository

    {
        public ProjectRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
        }

        public async Task<Project> FindById(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<IEnumerable<Project>> ListAsync()
        {
          
            return await _context.Projects.Include(p=>p.ProjectLeader).ToListAsync();
        }
        //poner en el resto 
        public async Task<IEnumerable<Project>> ListByProjectLeaderIdAsync(int projectLeaderId)
        {
            return await _context.Projects.AsNoTracking().Where(c => c.ProjectLeaderId == projectLeaderId).ToListAsync();
        }

        public async  Task<IEnumerable<Project>> ListBytagName(string tag)
        {
            return await _context.Projects
                .Where(p => p.Tag.Name == tag)
                .ToListAsync();
        }

        public void Remove(Project project)
        {
            _context.Projects.Remove(project);
        }

        public void Update(Project project)
        {
            _context.Projects.Update(project);
        }

        public async Task AssignProjectLeader(int projectId, int userId)
        {
            Project projectLeader = await FindById(projectId);
            if (projectLeader == null)
            {
                projectLeader = new Project { Id = projectId, ProjectLeaderId = userId };
                await AddAsync(projectLeader);
            }
        }

        public async Task AssignProjectTag(int projectId, int tagId)
        {
            Project projectTag = await FindById(projectId);
            if (projectTag == null)
            {
                projectTag = new Project { Id = projectId, TagId = tagId };
                await AddAsync(projectTag);
            }
        }

        public async void UnassignProjectLeader(int projectId, int userId)
        {
            Project projectLeader = await FindById(projectId);
            if (projectLeader == null)
            {
                Remove(projectLeader);
            }
        }

        public async void UnassignProjectTag(int projectId, int tagId)
        {
            Project projectTag = await FindById(projectId);
            if (projectTag == null)
            {
                Remove(projectTag);
            }
        }

    }
}
