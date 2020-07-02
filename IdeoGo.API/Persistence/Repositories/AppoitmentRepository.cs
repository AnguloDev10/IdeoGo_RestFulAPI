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
    public class AppoitmentRepository : BaseRepository, IAppoitmentRepository
    {
        public AppoitmentRepository(AppDbContext context): base(context)
        {

        }

        public async Task AddAsync(Appoitment appoitment)
        {
            await _context.Appoitments.AddAsync(appoitment);
        }

        public async Task<Appoitment> FindByIDAsync(int id)
        {
            return await _context.Appoitments.FindAsync(id);
        }

        public async Task<IEnumerable<Appoitment>> ListAsync()
        {
            return await _context.Appoitments.ToListAsync();
        }

        public void Remove(Appoitment appoitment)
        {
            _context.Appoitments.Remove(appoitment);
        }

        public void Update(Appoitment appoitment)
        {
            _context.Appoitments.Update(appoitment);
        }

  

        public async Task AssignAppointmentSchedule(int appointId, int schedId)
        {
            Appoitment appointmentSchedule = await FindByIDAsync(appointId);
            if (appointmentSchedule == null)
            {
                appointmentSchedule = new Appoitment { Id = appointId, ProjectScheduleId = schedId };
                await AddAsync(appointmentSchedule);
            }
        }


        public async void UnassignAppointmentSchedule(int appointId, int schedId)
        {
            Appoitment appointmentSchedule = await FindByIDAsync(appointId);
            if (appointmentSchedule == null)
            {
                Remove(appointmentSchedule);
            }
        }
    }
}
