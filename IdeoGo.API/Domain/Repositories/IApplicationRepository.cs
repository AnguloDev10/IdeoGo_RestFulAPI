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
        Task AddAsync(Application application);
        void Update(Application application);
        void Remove(Application application);
        Task<Application> FindByIDAsync(int id);

    }
}
