using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    interface UserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddAsync(User user);
    }
}
