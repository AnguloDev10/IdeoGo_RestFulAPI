using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Domain.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Persistence.Repositories
{
    public class ProjectScheduleRepository : BaseRepository, IProjectScheduleRepository
    {
        public ProjectScheduleRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<ProjectSchedule>> ListAsync()
        {

            return await _context.ProjectsSchedules.ToListAsync();
        }

        public async Task AddAsync(ProjectSchedule projectSchedule)
        {
            await _context.ProjectsSchedules.AddAsync(projectSchedule);
        }

        public async Task<ProjectSchedule> FindById(int id)
        {
            return await _context.ProjectsSchedules.FindAsync(id);
        }

        public void Update(ProjectSchedule projectSchedule)
        {
            _context.ProjectsSchedules.Update(projectSchedule);
        }

        public void Remove(ProjectSchedule projectSchedule)
        {
            _context.ProjectsSchedules.Remove(projectSchedule);
        }

        public async Task<IEnumerable<ProjectSchedule>> ListByProjectIdAsync(int projectId)
        {
            return await _context.ProjectsSchedules.Where(p => p.ProjectId == projectId).ToListAsync();
        }

        public async Task AssignScheduleProject(int scheduleId, int projectId)
        {
            ProjectSchedule scheduleProject = await FindById(scheduleId);
            if (scheduleProject == null)
            {
                scheduleProject = new ProjectSchedule { Id = scheduleId, ProjectId = projectId };
                await AddAsync(scheduleProject);
            }
        }

        public async void UnassignScheduleProject(int scheduleId, int projectId)
        {
            ProjectSchedule scheduleProject = await FindById(scheduleId);
            if (scheduleProject == null)
            {
                Remove(scheduleProject);
            }
        }
    }
}
