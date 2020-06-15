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
            var existingTag = await _appoitmentRepository.FindByIDAsync(id);

            if (existingTag == null)
                return new AppoitmentResponse("Appoitment not found");

            try
            {
                _appoitmentRepository.Remove(existingTag);
                await _unitOfWork.CompleteAsync();

                return new AppoitmentResponse(existingTag);
            }
            catch (Exception ex)
            {
                return new AppoitmentResponse($"An error ocurred while deleting tag: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Appoitment>> ListAsync()
        {
            return await _appoitmentRepository.ListAsync();
        }

        public async Task<AppoitmentResponse> SaveAsync(Appoitment appoitment)
        {
            try
            {
                await _appoitmentRepository.AddAsync(appoitment);
                await _unitOfWork.CompleteAsync();

                return new AppoitmentResponse(appoitment);
            }
            catch (Exception ex)
            {
                return new AppoitmentResponse($"An error ocurred while saving the tag: {ex.Message}");
            }
        }

        public async Task<AppoitmentResponse> UpdateAsync(int id, Appoitment appoitment)
        {
            var existingTag = await _appoitmentRepository.FindByIDAsync(id);

            if (existingTag == null)
                return new AppoitmentResponse("Appoitment not found");

            existingTag.Date = appoitment.Date;

            try
            {
                _appoitmentRepository.Update(existingTag);
                await _unitOfWork.CompleteAsync();

                return new AppoitmentResponse(existingTag);
            }
            catch (Exception ex)
            {
                return new AppoitmentResponse($"An error ocurred while updating tag: {ex.Message}");
            }
        }
    }
}
