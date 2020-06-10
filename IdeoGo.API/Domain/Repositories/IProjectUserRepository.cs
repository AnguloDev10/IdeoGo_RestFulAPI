using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeoGo.API.Domain.Models;

namespace IdeoGo.API.Domain.Repositories
{
    public interface IProjectUserRepository
    {
        Task<IEnumerable<ProjectUser>> ListAsync();
        Task<IEnumerable<ProjectUser>> ListByProjectIdAsync(int projectId);
        Task<IEnumerable<ProjectUser>> ListByUserIdAsync(int userId);
        Task<ProjectUser> FindByProjectIdAndUserId(int projectId, int userId);
        Task AddAsync(ProjectUser projectUser);
        void Remove(ProjectUser projectUser);
        Task AssignProjectUser(int projectId, int userId);
        void UnassignProjectUser(int projectId, int userId);
    }
}
