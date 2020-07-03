using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services.Communications;

namespace IdeoGo.API.Domain.Services
{
    public interface IProjectUserService
    {
        Task<IEnumerable<ProjectUser>> ListAsync();
        Task<IEnumerable<ProjectUser>> ListByProjectIdAsync(int projectId);
        Task<IEnumerable<ProjectUser>> ListByUserIdAsync(int userId);
        Task<ProjectUserResponse> AssignProjectUserAsync(int projectId, int userId);
        Task<ProjectUserResponse> UnassignProjectUserAsync(int projectId, int userId);


    }
}
