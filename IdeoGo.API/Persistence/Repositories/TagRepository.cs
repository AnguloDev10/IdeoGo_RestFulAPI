using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Domain.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

namespace IdeoGo.API.Persistence.Repositories
{
    public class TagRepository : BaseRepository, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
        }

        public async  Task<Tag> FindByIDAsync(int id)
        {
            return await _context.Tags.FindAsync(id);
        }

        public async Task<IEnumerable<Tag>> ListAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public void Remove(Tag tag)
        {
            _context.Tags.FindAsync(tag);
        }

        public void Update(Tag tag)
        {
            _context.Tags.Update(tag);
        }

        public async Task<IEnumerable<Tag>> ListByCategoryIdAsync(int categoryId) => ////lambda
            await _context.Tags
            .Where(p => p.CategoryId == categoryId)
            .Include(p => p.Category)
            .ToListAsync();

        public async Task AssignCategoryTag(int categoryId, int tagId)
        {
            Tag TagCategory = await FindByIDAsync(tagId);
            if (TagCategory == null)
            {
                TagCategory = new Tag { Id = tagId, CategoryId = categoryId };
                await AddAsync(TagCategory);
            }
        }

        public async void UnassignCategoryTag(int categoryId, int tagId)
        {
            Tag TagCategory = await FindByIDAsync(tagId);
            if (TagCategory == null)
            {
               Remove(TagCategory);
            }
        }
    }
}
