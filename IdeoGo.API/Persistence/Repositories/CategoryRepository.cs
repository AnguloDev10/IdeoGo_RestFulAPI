using IdeoGo.API.Domain.Models;
using IdeoGo.API.Persistences.Contexts;
using IdeoGo.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {

        public CategoryRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Category category)
        {
            await _context.Category.AddAsync(category);
        }


        public async Task<Category> FindByIDAsync(int id)
        {
            return await _context.Category.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Category.ToListAsync();
        }

        public void Remove(Category category)
        {
            _context.Category.Remove(category);
        }

        public void Update(Category category)
        {
            _context.Category.Update(category);
        }

        public void Update(Task<Category> existingCategory)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Category>> ICategoryRepository.ListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
