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
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        public readonly IUnitOfWork _unitOfWork;

        public ActivityService(IActivityRepository activityRepository, IUnitOfWork unitOfWork)
        {
            _activityRepository = activityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ActivityResponse> DeleteAsync(int id)
        {
            var existingActivity = await _activityRepository.FindByIDAsync(id);

            if (existingActivity == null)
                return new ActivityResponse("Activity not found.");

            try
            {
                _activityRepository.Remove(existingActivity);


                return new ActivityResponse(existingActivity);
            }
            catch (Exception ex)
            {
                return new ActivityResponse($"An error ocurred while deleting the Activity : {ex.Message}");
            }
        }

        public async Task<ActivityResponse> GetByIdAsync(int id)
        {
            var existingActivity = await _activityRepository.FindByIDAsync(id);

            if (existingActivity == null)
                return new ActivityResponse("Activity not found");
            return new ActivityResponse(existingActivity);
        }

        public async Task<IEnumerable<Activity>> ListAsync()
        {
            return await _activityRepository.ListAsync();
        }

        public async Task<ActivityResponse> SaveAsync(Activity activity)
        {
            try
            {
                await _activityRepository.AddAsync(activity);

                return new ActivityResponse(activity);
            }
            catch (Exception ex)
            {
                return new ActivityResponse($"An error ocurred while saving the Activity: {ex.Message}");
            }
        }

        public async Task<ActivityResponse> UpdateAsync(int id, Activity activity)
        {
            var existingActivity = await _activityRepository.FindByIDAsync(id);

            if (existingActivity == null)
                return new ActivityResponse("Activity not found");

            existingActivity.Name = activity.Name;

            try
            {
                _activityRepository.Update(existingActivity);

                return new ActivityResponse(existingActivity);
            }
            catch (Exception ex)
            {
                return new ActivityResponse($"An error ocurred while updating Activity: {ex.Message}");
            }
        }
    }
}
