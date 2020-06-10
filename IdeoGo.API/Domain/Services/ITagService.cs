using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> ListAsync();
        Task<TagResponse> SaveAsync(Tag tag);

        Task<IEnumerable<Tag>> ListByCategoryIdAsync(int categoryId);
        Task<TagResponse> UpdateAsync(int id, Tag tag);
        Task<TagResponse> DeleteAsync(int id);

        
    }
}