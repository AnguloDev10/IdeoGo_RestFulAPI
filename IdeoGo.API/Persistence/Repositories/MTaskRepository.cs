using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Persistence.Contexts;
using IdeoGo.API.Domain.Repositories;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Persistence.Repositories
{
    public class MTaskRepository : BaseRepository, IMTaskRepository
    {
        public MTaskRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<MTask>> ListAsync()
        {

            return await _context.Tasks.ToListAsync();
        }

        public async Task AddAsync(MTask mTask)
        {
            await _context.Tasks.AddAsync(mTask);
        }

        public async Task<MTask> FindById(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public void Update(MTask mTask)
        {
            _context.Tasks.Update(mTask);
        }

        public void Remove(MTask mTask)
        {
            _context.Tasks.Remove(mTask);
        }
    }
}
