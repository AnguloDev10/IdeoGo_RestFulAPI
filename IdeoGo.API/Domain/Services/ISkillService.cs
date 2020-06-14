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

    }
}
