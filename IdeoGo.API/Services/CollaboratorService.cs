using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Domain.Services;
using IdeoGo.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Services
{
    public class CollaboratorService : ICollaboratorService
    {
        private readonly ICollaboratorRepository _collaborateRepository;

        public CollaboratorService(ICollaboratorRepository collaborateRepository)
        {
            _collaborateRepository = collaborateRepository;
        }

        public Task<CollaboratorResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Collaborator>> ListAsync()
        {
            return await _collaborateRepository.ListAsync();
        }

        public Task<CollaboratorResponse> SaveAsync(Collaborator collaborator)
        {
            throw new NotImplementedException();
        }

        public Task<CollaboratorResponse> UpdateAsync(int id, Collaborator collaborator)
        {
            throw new NotImplementedException();
        }
    }
}
