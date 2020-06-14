using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services
{
    public interface IMembershipService
    {
        Task<IEnumerable<Membership>> ListAsync();
        Task<MembershipResponse> GetByIdAsync(int id);
        Task<MembershipResponse> SaveAsync(Membership membership);
        Task<MembershipResponse> DeleteAsync(int id);
        Task<MembershipResponse> UpdateAsync(int id, Membership membership);
    }
}
