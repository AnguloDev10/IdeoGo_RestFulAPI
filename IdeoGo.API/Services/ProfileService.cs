using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Domain.Services;
using IdeoGo.API.Domain.Services.Communication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Services
{
    public class ProfileService : IProfileService
    {
        public Task<ProfileResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Profile>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProfileResponse> SaveAsync(Profile profile)
        {
            throw new NotImplementedException();
        }

        public Task<ProfileResponse> UpdateAsync(int id, Profile profile)
        {
            throw new NotImplementedException();
        }
    }
}

