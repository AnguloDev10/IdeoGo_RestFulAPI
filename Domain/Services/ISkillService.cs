using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services
{
    public interface ISkillService
    {
        Task<IEnumerable<Skill>> ListAsync();

        Task<SkillResponse> SaveAsync(Skill skill);

        Task<SkillResponse> UpdateAsync(int id, Skill skill);
        Task<SkillResponse> DeleteAsync(int id);

        Task<SkillResponse> AssignSkillTagAsync(int skillId, int tagId);
        Task<SkillResponse> UnassignSkillTagAsync(int skillId, int tagId);

        Task<SkillResponse> AssignSkillProfileAsync(int skillId, int profileId);
        Task<SkillResponse> UnassignSkillProfileAsync(int skillId, int profileId);

    }
}
