using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    public interface IMTaskRepository
    {
        Task<IEnumerable<MTask>> ListAsync();
        Task AddAsync(MTask mTask);
        Task<MTask> FindById(int id);
        void Update(MTask mTask);
        void Remove(MTask mTask);
    }
}
