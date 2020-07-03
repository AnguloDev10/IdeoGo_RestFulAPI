using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    public interface IResourceRepository
    {
        Task<IEnumerable<Resource>> ListAsync();
        Task AddAsync(Resource resource);
        void Update(Resource resource);
        void Remove(Resource resource);
        Task<Resource> FindByIdAsync(int id);
    }
}
