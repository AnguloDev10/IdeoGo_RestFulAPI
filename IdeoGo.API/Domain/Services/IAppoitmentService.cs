using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Services
{
    public interface IAppoitmentService
    {

        Task<IEnumerable<Appoitment>> ListAsync();

        Task<AppoitmentResponse> SaveAsync(Appoitment appoitment);

        Task<AppoitmentResponse> UpdateAsync(int id, Appoitment appoitment);
        Task<AppoitmentResponse> DeleteAsync(int id);




    }
}
