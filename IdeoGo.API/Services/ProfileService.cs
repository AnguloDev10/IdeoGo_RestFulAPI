using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRespository _profileRespository;

        public ProfileService(IProfileRespository profileRespository)
        {
            _profileRespository = profileRespository;
        }

        public Task<IEnumerable<Profile>> ListAsync()
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<Profile>> ListAsync()
        //{
        //    return await _profileRespository.ListAsync();
        //}
        //public  async Task<IEnumerable<Profile>> ListAsync()
        //{
        //    return await _profileRespository.ListAsync();
        //}
    }
}

