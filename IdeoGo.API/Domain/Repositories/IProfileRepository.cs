using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    public interface IProfileRepository
    {

        Task<IEnumerable<Profile>> ListAsync();
        Task AddAsync(Profile profile);
        void Update(Profile profile);
        void Remove(Profile profile);

        Task<Profile> FindById(int id);
    }

}

