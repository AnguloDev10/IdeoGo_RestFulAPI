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
        Task AddAsync(Project project);
        Task<Project> FindById(int id);
        void Update(Project project);
        void Remove(Project project);
    }
}
