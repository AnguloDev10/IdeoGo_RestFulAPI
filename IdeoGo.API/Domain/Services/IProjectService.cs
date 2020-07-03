using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services.Communications;

namespace IdeoGo.API.Domain.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> ListAsync();
        Task<IEnumerable<Project>> ListByApplicationUserIdAsync(int appUserId);
        Task<IEnumerable<Project>> ListByProjectLeaderIdAsync(int projectLeaderId);
        Task<IEnumerable<Project>> ListByProjectUserByUserIdAsync(int userId);
        Task<IEnumerable<Project>> ListByTagName(string tag);
        Task<ProjectResponse> GetByIdAsync(int id);
        Task<ProjectResponse> SaveAsync(Project project);
        Task<ProjectResponse> UpdateAsync(int id, Project project);
        Task<ProjectResponse> DeleteAsync(int id);


        Task<ProjectResponse> AssignProjectLeaderAsync(int projectId, int userId);
        Task<ProjectResponse> UnassignProjectLeaderAsync(int projectId, int userId);

        Task<ProjectResponse> AssignProjectTagAsync(int projectId, int tagId);
        Task<ProjectResponse> UnassignProjectTagAsync(int projectId, int tagId);

    }
}
