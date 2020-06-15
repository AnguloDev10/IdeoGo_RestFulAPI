using AutoMapper;
using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Domain.Services;
using IdeoGo.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Services
{
    public class AppoitmentService : IAppoitmentService
    {
        private readonly IAppoitmentRepository _appoitmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppoitmentService(IAppoitmentRepository appointmentRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _appoitmentRepository = appointmentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AppoitmentResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Appoitment>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AppoitmentResponse> SaveAsync(Appoitment appoitment)
        {
            throw new NotImplementedException();
        }

        public async Task<AppoitmentResponse> UpdateAsync(int id, Appoitment appoitment)
        {
            throw new NotImplementedException();
        }
    }
}
