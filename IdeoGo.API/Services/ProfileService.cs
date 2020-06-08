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
        private readonly IProfileRepository _profileRepository;
        public readonly IUnitOfWork _unitOfWork;

        public ProfileService(IProfileRepository profileRepository, IUnitOfWork unitOfWork)
        {
            _profileRepository = profileRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ProfileResponse> DeleteAsync(int id)
        {
            var existingProfile = await _profileRepository.FindById(id);

            if (existingProfile == null)
                return new ProfileResponse("Profile not found");

            try
            {
                _profileRepository.Remove(existingProfile);
                await _unitOfWork.CompleteAsync();

                return new ProfileResponse(existingProfile);
            }
            catch (Exception ex)
            {
                return new ProfileResponse($"An error ocurred while deleting profile: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Profile>> ListAsync()
        {
            return await _profileRepository.ListAsync();
        }

        public async Task<ProfileResponse> SaveAsync(Profile profile)
        {
            try
            {
                await _profileRepository.AddAsync(profile);
                await _unitOfWork.CompleteAsync();

                return new ProfileResponse(profile);
            }
            catch (Exception ex)
            {
                return new ProfileResponse($"An error ocurred while saving the profile: {ex.Message}");
            }
        }

        public async Task<ProfileResponse> UpdateAsync(int id, Profile profile)
        {
            var existingProfile = await _profileRepository.FindById(id);

            if (existingProfile == null)
                return new ProfileResponse("Profile not found");

            existingProfile.Name = profile.Name;
            existingProfile.Gender = profile.Gender;
            existingProfile.Age = profile.Age;
            existingProfile.Occupation = profile.Occupation;
            existingProfile.TypeUser = profile.TypeUser;

            try
            {
                _profileRepository.Update(existingProfile);
                await _unitOfWork.CompleteAsync();

                return new ProfileResponse(existingProfile);
            }
            catch (Exception ex)
            {
                return new ProfileResponse($"An error ocurred while updating profile: {ex.Message}");
            }
        }
    }
}

