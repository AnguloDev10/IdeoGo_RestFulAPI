using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    interface IProjectRepository
    {
        Task<IEnumerable<Project>> ListAsync();
        Task AddAsync(Project project);

        void Update(Project project);
        void Remove(Project project);

        Task<Project> FindByIDAsync(int id);
    }
}
