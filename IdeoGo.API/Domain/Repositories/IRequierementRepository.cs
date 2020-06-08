using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    public interface IRequierementRepository
    {
        Task<IEnumerable<Requierement>> ListAsync();
        Task AddAsync(Requierement requierement);
        void Update(Requierement requierement);
        void Remove(Requierement requierement);
        Task<Requierement> FindByIdAsync(int id);
    }
}
