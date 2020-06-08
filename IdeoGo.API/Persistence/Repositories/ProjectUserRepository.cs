using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Persistence.Contexts;
using IdeoGo.API.Domain.Repositories;

namespace IdeoGo.API.Persistence.Repositories
{
    public class ProjectUserRepository : BaseRepository, IProjectUserRepository
    {

        public ProjectUserRepository(AppDbContext context) : base(context) { }


        public async Task AddAsync(ProjectUser projectUser)
        {
            await _context.ProjectUsers.AddAsync(projectUser);
        }

        public async Task AssignProjectUser(int projectId, int userId)
        {
            ProjectUser projectUser = await FindByProjectIdAndUserId(projectId, userId);
            if (projectUser == null)
            {
                projectUser = new ProjectUser { ProjectId = projectId, UserId = userId };
                await AddAsync(projectUser);
            }
        }

        public async Task<ProjectUser> FindByProjectIdAndUserId(int projectId, int userId)
        {
            return await _context.ProjectUsers.FindAsync(projectId, userId);
        }

        public async Task<IEnumerable<ProjectUser>> ListAsync()
        {
            return await _context.ProjectUsers
                .Include(pt => pt.Project)
                .Include(pt => pt.User)
                .ToListAsync();
        }

        public async  Task<IEnumerable<ProjectUser>> ListByProjectIdAsync(int projectId)
        {
            return await _context.ProjectUsers
                 .Where(pt => pt.ProjectId == projectId)
                 .Include(pt => pt.Project)
                 .Include(pt => pt.User)
                 .ToListAsync();
        }

        public async Task<IEnumerable<ProjectUser>> ListByUserIdAsync(int userId)
        {
            return await _context.ProjectUsers
                .Where(pt => pt.UserId == userId)
                .Include(pt => pt.Project)
                .Include(pt => pt.User)
                .ToListAsync();
        }

        public void Remove(ProjectUser projectUser)
        {
            _context.ProjectUsers.Remove(projectUser);
        }

        public async  void UnassignProjectUser(int projectId, int userId)
        {

            ProjectUser projectUser = await FindByProjectIdAndUserId(projectId, userId);
            if (projectUser != null)
            {
                Remove(projectUser);
            }
        }
    }
}
