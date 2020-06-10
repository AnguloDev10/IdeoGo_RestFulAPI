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


    }
}
