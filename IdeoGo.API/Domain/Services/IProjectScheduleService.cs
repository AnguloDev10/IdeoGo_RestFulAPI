using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services
{
    public interface IProjectScheduleService
    {
        Task<IEnumerable<ProjectSchedule>> ListAsync();
        Task<IEnumerable<ProjectSchedule>> ListByProjectIdAsync(int projectId);
        Task<ProjectScheduleResponse> GetByIdAsync(int id);
        Task<ProjectScheduleResponse> SaveAsync(ProjectSchedule projectSchedule);
        Task<ProjectScheduleResponse> UpdateAsync(int id, ProjectSchedule projectSchedule);
        Task<ProjectScheduleResponse> DeleteAsync(int id);
        Task<ProjectScheduleResponse> AssignScheduleProjectAsync(int scheduleId, int projectId);
        Task<ProjectScheduleResponse> UnassignScheduleProjectAsync(int scheduleId, int projectId);
    }
}
