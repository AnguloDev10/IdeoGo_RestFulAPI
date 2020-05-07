using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    public interface ICollaboratorRepository
    {
            

        Task<IEnumerable<Collaborator>> ListAsync();
        Task AddAsync(Collaborator collaborator);

        Task<Collaborator> FindByIDAsync(int id);
        void Update(Collaborator collaborator);
        void Update(Task<Collaborator> existingCategory);

        void Remove(Collaborator collaborator);
    }
}
