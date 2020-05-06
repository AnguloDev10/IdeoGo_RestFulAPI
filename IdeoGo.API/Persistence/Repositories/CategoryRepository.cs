using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Persistences;
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

        public CategoryRepository(AppDbContext context) :base(context)
        {

        }
        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Category.ToListAsync();
        }
    }
}
