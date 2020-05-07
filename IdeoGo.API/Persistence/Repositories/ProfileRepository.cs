using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Persistences.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Persistence.Repositories
{
    public class ProfileRepository : BaseRepository, IProfileRespository
    {
        ProfileRepository(AppDbContext context) : base(context) { }

        public Task AddAsync(AutoMapper.Profile profile)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AutoMapper.Profile>> ListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
