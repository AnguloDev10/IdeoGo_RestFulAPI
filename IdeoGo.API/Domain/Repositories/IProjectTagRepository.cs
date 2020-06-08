using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeoGo.API.Domain.Models;

namespace IdeoGo.API.Domain.Repositories
{
    public interface IProjectTagRepository
    {
        Task<IEnumerable<ProjectTag>> ListAsync();
        Task<IEnumerable<ProjectTag>> ListByProjectIdAsync(int projectId);
        Task<IEnumerable<ProjectTag>> ListByTagIdAsync(int tagId);
        Task<ProjectTag> FindByProjectIdAndTagId(int projectId, int tagId);
        Task AddAsync(ProjectTag projectTag);
        void Remove(ProjectTag projectTag);
        Task AssignProjectTag(int projectId, int tagId);
        void UnassignProjectTag(int projectId, int tagId);

    }
}
