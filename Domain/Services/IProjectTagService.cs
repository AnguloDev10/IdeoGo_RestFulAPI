using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services.Communications;

namespace IdeoGo.API.Domain.Services
{
    public interface IProjectTagService
    {
        Task<IEnumerable<ProjectTag>> ListAsync();
        Task<IEnumerable<ProjectTag>> ListByProjectIdAsync(int projectId);
        Task<IEnumerable<ProjectTag>> ListByTagIdAsync(int tagId);
        Task<ProjectTagResponse> AssignProjectTagAsync(int projectId, int tagId);
        Task<ProjectTagResponse> UnassignProjectTagAsync(int projectId, int tagId);



    }
}
