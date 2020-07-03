using IdeoGo.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Repositories
{
    public interface IAppoitmentRepository
    {
        Task<IEnumerable<Appoitment>> ListAsync();
        Task AddAsync(Appoitment appoitment);
        void Update(Appoitment appoitment);
        void Remove(Appoitment appoitment);
        Task<Appoitment> FindByIDAsync(int id);

        Task AssignAppointmentSchedule(int appointId, int schedId);
        void UnassignAppointmentSchedule(int appointId, int schedId);
    }
}
