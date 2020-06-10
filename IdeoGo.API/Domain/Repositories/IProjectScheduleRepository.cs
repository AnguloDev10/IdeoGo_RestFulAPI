using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    public interface IProjectScheduleRepository
    {
        Task<IEnumerable<ProjectSchedule>> ListAsync();
        Task AddAsync(ProjectSchedule projectSchedule);
        Task<ProjectSchedule> FindById(int id);
        void Update(ProjectSchedule projectSchedule);
        void Remove(ProjectSchedule projectSchedule);
    }
}
