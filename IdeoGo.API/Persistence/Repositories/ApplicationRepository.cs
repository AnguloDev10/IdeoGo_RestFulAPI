using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeoGo.API.Domain.Persistence.Contexts;

namespace IdeoGo.API.Persistence.Repositories
{
    public class ApplicationRepository : BaseRepository, IApplicationRepository
    {
        public ApplicationRepository(AppDbContext context) : base(context) {}
        public async Task AddAsync(Application application)
        {
           await _context.Aplications.AddAsync(application);
        }
        public async Task<Application> FindByIDAsync(int id)
        {
            return await _context.Aplications.FindAsync(id);
        }

        public async Task<IEnumerable<Application>> ListAsync()
        {
            return await _context.Aplications.ToListAsync();
        }
        //falta implementar
        public async Task<IEnumerable<Application>> ListByProjectIdAsync(int projectId)
        {
            return await _context.Aplications.AsNoTracking()
                .Where(pt => pt.ProjectId == projectId)
                .Include(pt => pt.User)
                .Include(pt => pt.Project)
                .ToListAsync();
        }
        //falta implementar
        public async Task<IEnumerable<Application>> ListByUserIdAsync(int userId)
        {
            return await _context.Aplications.AsNoTracking()
                .Where(pt => pt.UserId == userId)
                .Include(pt => pt.User)
                .Include(pt => pt.Project)
                .ToListAsync();
        }

        public void Remove(Application application)
        {
            _context.Aplications.Remove(application);
        }

        public void Update(Application application)
        {
            _context.Aplications.Update(application);
        }

        public async Task AssignApplicationProject(int applicationId, int projectId)
        {
            Application applicationProject = await FindByIDAsync(applicationId);
            if (applicationProject == null)
            {
                applicationProject = new Application { Id = applicationId, ProjectId = projectId };
                await AddAsync(applicationProject);
            }
        }

        public async Task AssignApplicationUser(int applicationId, int userId)
        {
            Application applicationUser = await FindByIDAsync(applicationId);
            if (applicationUser == null)
            {
                applicationUser = new Application { Id = applicationId, UserId = userId };
                await AddAsync(applicationUser);
            }
        }

        public async void UnassignApplicationProject(int applicationId, int projectId)
        {
            Application applicationProject = await FindByIDAsync(applicationId);
            if (applicationProject == null)
            {
                Remove(applicationProject);
            }
        }

        public async void UnassignApplicationUser(int applicationId, int userId)
        {
            Application applicationUser = await FindByIDAsync(applicationId);
            if (applicationUser == null)
            {
                Remove(applicationUser);
            }
        }

    }
}
