using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services
{
    interface IRequestService
    {
        Task<IEnumerable<Request>> ListAsync();
        Task<RequestResponse> SaveAsync(Request request);

        Task<RequestResponse> UpdateAsync(int id, Request request);
        Task<RequestResponse> DeleteAsync(int id);
    }
}
