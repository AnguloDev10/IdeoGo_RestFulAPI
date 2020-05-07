using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services.Communication
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> ListAsync();
        Task<ProjectResponse> SaveAsync(Project project);

        Task<ProjectResponse> UpdateAsync(int id, Project project);
        Task<ProjectResponse> DeleteAsync(int id);
    }
}
