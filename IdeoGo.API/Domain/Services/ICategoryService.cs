

using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services
{
    ///Actividad que se realice de forma asincrona para no obstruir otras peticiones
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
    }
}
