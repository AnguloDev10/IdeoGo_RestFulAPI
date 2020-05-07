using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services
{
    public interface IGoalService
    {
        Task<IEnumerable<Goal>> ListAsync();
    }
}
