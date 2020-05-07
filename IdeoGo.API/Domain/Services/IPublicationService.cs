using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services
{
    public interface IPublicationService
    {
        Task<IEnumerable<Publication>> ListAsync();
        Task<PublicationResponse> SaveAsync(Publication publication);

        Task<PublicationResponse> UpdateAsync(int id, Publication publication);
        Task<PublicationResponse> DeleteAsync(int id);
    }

}
