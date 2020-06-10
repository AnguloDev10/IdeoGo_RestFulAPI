using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> ListAsync();
        Task AddAsync(Tag tag);

        void Update(Tag tag);
        void Remove(Tag tag);
        Task<Tag> FindByIDAsync(int id);

        Task<IEnumerable<Tag>> ListByCategoryIdAsync(int categoryId);
    }
}
