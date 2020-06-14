using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    public interface IMembershipRepository
    {
        Task AddAsync(Membership membership);
        Task<Membership> FindByIdAsync(int id);
        Task<IEnumerable<Membership>> ListAsync();

        void Remove(Membership existingMembership);
        void Update(Membership existingMembership);
    }
}
