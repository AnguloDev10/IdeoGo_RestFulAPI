using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeoGo.API.Domain.Models;

namespace IdeoGo.API.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> ListAsync();
        Task<IEnumerable<Project>> ListByProjectLeaderIdAsync(int projectLeaderId);
        Task<IEnumerable<Project>> ListBytagName(string name);
        Task AddAsync(Project project);
        Task<Project> FindById(int id);
        void Update(Project project);
        void Remove(Project project);

        Task AssignProjectTag(int projectId, int tagId);
        void UnassignProjectTag(int projectId, int tagId);


        Task AssignProjectLeader(int projectId, int userId);
        void UnassignProjectLeader(int projectId, int userId);
    }
}
