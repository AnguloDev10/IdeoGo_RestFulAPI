using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services
{
    public interface IRequierementService
    {
        Task<IEnumerable<Requierement>> ListAsync();

        Task<RequierementResponse> SaveAsync(Requierement requierement);

        Task<RequierementResponse> UpdateAsync(int id, Requierement requierement);
        Task<RequierementResponse> DeleteAsync(int id);
    }
}
