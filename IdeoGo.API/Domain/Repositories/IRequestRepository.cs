using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    public interface IRequestRepository
    {
        Task<IEnumerable<Request>> ListAsync();
        Task AddAsync(Request request);
    }
}
