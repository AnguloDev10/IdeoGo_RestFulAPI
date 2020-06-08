using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services
{
    public interface IResourceService
    {
        Task<IEnumerable<Resource>> ListAsync();

        Task<ResourceResponse> SaveAsync(Resource resource);

        Task<ResourceResponse> UpdateAsync(int id, Resource resource);
        Task<ResourceResponse> DeleteAsync(int id);

    }
}
