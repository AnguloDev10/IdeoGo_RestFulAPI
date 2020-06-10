using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services
{
    public interface IProfileService
    {
        Task<IEnumerable<Profile>> ListAsync();
        Task<ProfileResponse> SaveAsync(Profile profile);

        Task<ProfileResponse> UpdateAsync(int id, Profile profile);
        Task<ProfileResponse> DeleteAsync(int id);
    }
}
