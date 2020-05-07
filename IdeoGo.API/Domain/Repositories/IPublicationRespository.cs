using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    public interface IPublicationRespository
    {
        Task<IEnumerable<Publication>> ListAsync();
        Task AddAsync(Publication publication);
        void Update(Publication publication);
        void Remove(Publication publication);
        Task<Publication> FindByIDAsync(int id);
    }
}

