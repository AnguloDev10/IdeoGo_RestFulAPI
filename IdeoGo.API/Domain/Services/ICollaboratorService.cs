using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services
{
    interface ICollaboratorService
    {
        Task<IEnumerable<Collaborator>> ListAsync();

        Task<CollaboratorResponse> SaveAsync(Collaborator collaborator);

        Task<CollaboratorResponse> UpdateAsync(int id, Collaborator collaborator);
        Task<CollaboratorResponse> DeleteAsync(int id);
    }
}
