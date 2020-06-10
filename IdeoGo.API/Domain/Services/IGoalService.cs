using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services
{
    public interface IGoalService
    {
        Task<IEnumerable<Goal>> ListAsync();

        Task<GoalResponse> SaveAsync(Goal goal);

        Task<GoalResponse> UpdateAsync(int id, Goal goal);
        Task<GoalResponse> DeleteAsync(int id);
    }
}
