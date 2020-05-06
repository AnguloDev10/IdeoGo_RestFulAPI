using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    interface IEntrepreneurRepository
    {
        Task<IEnumerable<Entrepreneur>> ListAsync();
        Task AddAsync(Entrepreneur entrepreneur);
    }
}
