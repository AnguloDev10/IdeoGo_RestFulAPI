using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services
{
    public interface IActivityService
    {
        Task<IEnumerable<Activity>> ListAsync();
        Task<ActivityResponse> GetByIdAsync(int id);
        Task<ActivityResponse> SaveAsync(Activity activity);
        Task<ActivityResponse> UpdateAsync(int id, Activity activity);
        Task<ActivityResponse> DeleteAsync(int id);
    }
}
