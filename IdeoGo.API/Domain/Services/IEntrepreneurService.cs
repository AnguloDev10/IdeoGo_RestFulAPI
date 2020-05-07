using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services
{
    public interface IEntrepreneurService
    {
        Task<IEnumerable<Entrepreneur>> ListAsync();

        Task<EntrepreneurResponse> SaveAsync(Entrepreneur entrepreneur);

        Task<EntrepreneurResponse> UpdateAsync(int id, Entrepreneur entrepreneur);
        Task<EntrepreneurResponse> DeleteAsync(int id);
    }
}
