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
        Task<ProjectResponse> GetByIdAsync(int id);
        Task<ProjectResponse> SaveAsync(Project project);
        Task<ProjectResponse> UpdateAsync(int id, Project project);
        Task<ProjectResponse> DeleteAsync(int id);




    }
}
