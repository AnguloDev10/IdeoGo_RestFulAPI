using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddAsync(User user);

        void Update(User user);
        void Remove(User user);
        Task<User> FindByIDAsync(int id);
    }
}

