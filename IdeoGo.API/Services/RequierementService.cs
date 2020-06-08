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
    public class RequierementService : IRequierementService
    {

        private readonly IRequierementRepository _requierementRepository;
        public readonly IUnitOfWork _unitOfWork;

        public RequierementService(IRequierementRepository requierementRepository, IUnitOfWork unitOfWork)
        {
            _requierementRepository = requierementRepository;
            _unitOfWork = unitOfWork;
        }

        public RequierementService(IRequierementRepository requierementRepository)
        {
            _requierementRepository = requierementRepository;
        }

        public async Task<RequierementResponse> DeleteAsync(int id)
        {
            var existingRequierement = await _requierementRepository.FindByIdAsync(id);

            if (existingRequierement == null)
                return new RequierementResponse("requierement not found.");

            try
            {
                _requierementRepository.Remove(existingRequierement);


                return new RequierementResponse(existingRequierement);

            }
            catch (Exception ex)
            {
                return new RequierementResponse($"An error ocurred while deleting the requierement : {ex.Message}");
            }
        }

        public async Task<IEnumerable<Requierement>> ListAsync()
        {
            return await _requierementRepository.ListAsync();
        }

        public async Task<RequierementResponse> SaveAsync(Requierement requierement)
        {
            try
            {
                await _requierementRepository.AddAsync(requierement);

                return new RequierementResponse(requierement);
            }
            catch (Exception ex)
            {

                return new RequierementResponse($"An error ocurred while saving the requierement : {ex.Message}");
            }
            throw new NotImplementedException();
        }

        public async Task<RequierementResponse> UpdateAsync(int id, Requierement requierement)
        {
            var existingRequierement = await _requierementRepository.FindByIdAsync(id);

            if (existingRequierement == null)
                return new RequierementResponse("Requierement not found.");
            existingRequierement.Name = requierement.Name;
            try
            {
                _requierementRepository.Update(existingRequierement);

                return new RequierementResponse(existingRequierement);
            }
            catch (Exception ex)
            {
                return new RequierementResponse($"An error ocurred while updating the requierement : {ex.Message}");
            }

            throw new NotImplementedException();
        }
    }
}
