using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    public interface IProfileRespository
    {

        Task<IEnumerable<Profile>> ListAsync();
        Task AddAsync(Profile profile);

    }


}