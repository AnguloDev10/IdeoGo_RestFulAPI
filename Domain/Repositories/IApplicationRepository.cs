using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    public interface IApplicationRepository
    {

        Task<IEnumerable<Application>> ListAsync();
        Task<IEnumerable<Application>> ListByUserIdAsync(int userId);
        Task<IEnumerable<Application>> ListByProjectIdAsync(int projectId);
        Task AddAsync(Application application);
        void Update(Application application);
        void Remove(Application application);
        Task<Application> FindByIDAsync(int id);

        Task AssignApplicationProject(int userId, int projectId);
        void UnassignApplicationProject(int applicationId, int projectId);


        Task AssignApplicationUser(int applicationId, int userId);
        void UnassignApplicationUser(int applicationId, int userId);

    }
}
