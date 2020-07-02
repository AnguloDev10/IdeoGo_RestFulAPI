using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Domain.Services;
using IdeoGo.API.Domain.Services.Communication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IProfileRepository _profileRepository;
        public readonly IUnitOfWork _unitOfWork;
        public readonly IProjectUserRepository _projectUserRepository;

        public ProfileService(IProfileRepository profileRepository, IUnitOfWork unitOfWork,
            IApplicationRepository applicationRepository,IProjectUserRepository projectUserRepository)
        {
            _profileRepository = profileRepository;
            _unitOfWork = unitOfWork;
            _applicationRepository = applicationRepository;
            _projectUserRepository = projectUserRepository;
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
        //implementar
        public async Task<IEnumerable<Profile>> ListByApplicationProjectIdAsync(int appProjectId)
        {
             List<Profile > ListAsync = new List<Profile>();
            var aplications = await _applicationRepository.ListByProjectIdAsync(appProjectId);
            var users = aplications.Select(pt => pt.User).ToList();
            var profiles = await _profileRepository.ListAsync();
            var result = (from us in users
                          join pro in profiles on us.Id equals pro.UserId
                          select new { Profile = pro });
           
             foreach(var item in result)
            {
                Profile pro = item.Profile;
                ListAsync.Add(pro);
            }
            return ListAsync;
        }

        public async Task<IEnumerable<Profile>> ListByProjectUserByProjectIdAsync(int projectId)
        {
            List<Profile> ListAsync = new List<Profile>();
            var projectUsers = await _projectUserRepository.ListByProjectIdAsync(projectId);
            var users =projectUsers.Select(pt => pt.User).ToList();
            var profiles = await _profileRepository.ListAsync();
            var result = (from us in users
                          join pro in profiles on us.Id equals pro.UserId
                          select new { Profile = pro });

            foreach (var item in result)
            {
                Profile pro = item.Profile;
                ListAsync.Add(pro);
            }
            return ListAsync;
        }


        public async Task<ProfileResponse> AssignProfileUserAsync(int profileId, int userId)
        {
            try
            {
                await _profileRepository.AssignProfileUser(profileId, userId);
                await _unitOfWork.CompleteAsync();
                Profile profile = await _profileRepository.FindById(profileId);
                return new ProfileResponse(profile);
            }
            catch (Exception ex)
            {
                return new ProfileResponse($"An error ocurred while assigning: {ex.Message}");
            }
        }

        public async Task<ProfileResponse> UnassignProfileUserAsync(int profileId, int userId)
        {
            try
            {
                Profile profile = await _profileRepository.FindById(profileId);
                _profileRepository.Remove(profile);
                await _unitOfWork.CompleteAsync();
                return new ProfileResponse(profile);
            }
            catch (Exception ex)
            {
                return new ProfileResponse($"An error ocurred while assigning: {ex.Message}");
            }
        }

        public async Task<ProfileResponse> AssignProfileTagAsync(int profileId, int tagId)
        {
            try
            {
                await _profileRepository.AssignProfileTag(profileId, tagId);
                await _unitOfWork.CompleteAsync();
                Profile profile = await _profileRepository.FindById(profileId);
                return new ProfileResponse(profile);
            }
            catch (Exception ex)
            {
                return new ProfileResponse($"An error ocurred while assigning: {ex.Message}");
            }
        }

        public async Task<ProfileResponse> UnassignProfileTagAsync(int profileId, int tagId)
        {
            try
            {
                Profile profile = await _profileRepository.FindById(profileId);
                _profileRepository.Remove(profile);
                await _unitOfWork.CompleteAsync();
                return new ProfileResponse(profile);
            }
            catch (Exception ex)
            {
                return new ProfileResponse($"An error ocurred while assigning: {ex.Message}");
            }
        }
    }
}

