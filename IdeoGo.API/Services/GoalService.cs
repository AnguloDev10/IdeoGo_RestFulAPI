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
    public class GoalService : IGoalService
    {
        private readonly IGoalRepository _goalRepository;

        public GoalService(IGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        public async Task<GoalResponse> DeleteAsync(int id)
        {
            var existingCategory = await _goalRepository.FindByIDAsync(id);

            if (existingCategory == null)
                return new GoalResponse("Category not found.");

            try
            {
                _goalRepository.Remove(existingCategory);

                return new GoalResponse(existingCategory);

            }
            catch (Exception ex)
            {
                return new GoalResponse($"An error ocurred while deleting the category : {ex.Message}");
            }
        }

        public async Task<IEnumerable<Goal>> ListAsync()
        {
            return await _goalRepository.ListAsync();
        }

        public async Task<GoalResponse> SaveAsync(Goal goal)
        {
            try
            {
                await _goalRepository.AddAsync(goal);

                return new GoalResponse(goal);
            }
            catch (Exception ex)
            {

                return new GoalResponse($"An error ocurred while saving the category : {ex.Message}");
            }
            throw new NotImplementedException();
        }

        public async Task<GoalResponse> UpdateAsync(int id, Goal goal)
        {
            var existingCategory = await _goalRepository.FindByIDAsync(id);

            if (existingCategory == null)
                return new GoalResponse("Category not found.");
            existingCategory.Name = goal.Name;
            existingCategory.Description = goal.Description;
            try
            {
                _goalRepository.Update(existingCategory);

                return new GoalResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new GoalResponse($"An error ocurred while updating the category : {ex.Message}");
            }

            throw new NotImplementedException();
        }
    }
}
