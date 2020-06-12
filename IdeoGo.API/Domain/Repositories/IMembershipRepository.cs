using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    interface IMembershipRepository
    {
        Task<DateTime> AddAsync();
        Task<int> GetIdMembershipAsync(DateTime now);
    }
}
