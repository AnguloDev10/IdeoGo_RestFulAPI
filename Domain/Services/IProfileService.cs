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
        Task<IEnumerable<Profile>>ListByApplicationProjectIdAsync(int appProjectId);
        Task<IEnumerable<Profile>> ListByProjectUserByProjectIdAsync(int projectId);

        Task<ProfileResponse> SaveAsync(Profile profile);

        Task<ProfileResponse> UpdateAsync(int id, Profile profile);
        Task<ProfileResponse> DeleteAsync(int id);

        Task<ProfileResponse> AssignProfileUserAsync(int profileId, int userId);
        Task<ProfileResponse> UnassignProfileUserAsync(int profileId, int userId);

        Task<ProfileResponse> AssignProfileTagAsync(int profileId, int tagId);
        Task<ProfileResponse> UnassignProfileTagAsync(int profileId, int tagId);
    }
}
