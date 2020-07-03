using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    public interface IProjectScheduleRepository
    {
        Task<IEnumerable<ProjectSchedule>> ListAsync();
        Task AddAsync(ProjectSchedule projectSchedule);
        Task<ProjectSchedule> FindById(int id);
        Task<IEnumerable<ProjectSchedule>> ListByProjectIdAsync(int projectId);
        void Update(ProjectSchedule projectSchedule);
        void Remove(ProjectSchedule projectSchedule);

        Task AssignScheduleProject(int scheduleId, int projectId);
        void UnassignScheduleProject(int scheduleId, int projectId);
    }
}
