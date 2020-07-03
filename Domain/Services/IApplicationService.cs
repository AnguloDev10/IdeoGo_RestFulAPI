using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services
{
    public interface IApplicationService
    {
        Task<IEnumerable<Application>> ListAsync();
        
        Task<ApplicationResponse> SaveAsync(Application application);

        Task<ApplicationResponse> UpdateAsync(int id, Application application);
        Task<ApplicationResponse> DeleteAsync(int id);

        Task<ApplicationResponse> AssignApplicationProjectAsync(int applicationId, int projectId);
        Task<ApplicationResponse> UnassignApplicationProjectAsync(int applicationId, int projectId);


        Task<ApplicationResponse> AssignApplicationUserAsync(int applicationId, int userId);
        Task<ApplicationResponse> UnassignApplicationUserAsync(int applicationId, int userId);
    }
}
