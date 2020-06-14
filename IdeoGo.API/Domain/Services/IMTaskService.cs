using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services
{
    public interface IMTaskService
    {
        Task<IEnumerable<MTask>> ListAsync();
        Task<MTaskResponse> GetByIdAsync(int id);
        Task<MTaskResponse> SaveAsync(MTask mTask);
        Task<MTaskResponse> UpdateAsync(int id, MTask mTask);
        Task<MTaskResponse> DeleteAsync(int id);
    }
}
