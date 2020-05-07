using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services;
using IdeoGo.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Services
{
    public class EntrepreneurService : IEntrepreneurService
    {
        public Task<EntrepreneurResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Entrepreneur>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EntrepreneurResponse> SaveAsync(Entrepreneur entrepreneur)
        {
            throw new NotImplementedException();
        }

        public Task<EntrepreneurResponse> UpdateAsync(int id, Entrepreneur entrepreneur)
        {
            throw new NotImplementedException();
        }
    }
}
