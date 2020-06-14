using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    public interface IGoalRepository
    {
        Task<IEnumerable<Goal>> ListAsync();
        Task AddAsync(Goal goal);
        void Update(Goal goal);
        void Remove(Goal goal);
        Task<Goal> FindByIDAsync(int id);
    }
}

