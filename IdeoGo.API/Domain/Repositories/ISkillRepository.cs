using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skill>> ListAsync();
        Task AddAsync(Skill skill);
        void Update(Skill skill);
        void Remove(Skill skill);
        Task<Skill> FindByIdAsync(int id);

        Task AssignSkillTag(int skillId, int tagId);
        void UnassignSkillTag(int skillId, int tagId);

        Task AssignSkillProfile(int skillId, int profileId);
        void UnassignSkillProfile(int skillId, int profileId);
    }
}
