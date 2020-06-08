using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    public interface IActivityRepository
    {
        Task<IEnumerable<Activity>> ListAsync();
        Task AddAsync(Activity activity);

        Task<Activity> FindByIDAsync(int id);
        void Update(Activity activity);
        void Remove(Activity activity);
    }
}
