using IdeoGo.API.Domain.Persistences;
using IdeoGo.API.Domain.Persistences.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;
        public  BaseRepository(AppDbContext context)
         {

            _context =context;
         }
    }

}
