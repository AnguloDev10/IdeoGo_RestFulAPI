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
        public readonly IUnitOfWork _unitOfWork;

        public GoalService(IGoalRepository goalRepository, IUnitOfWork unitOfWork)
        {
            _goalRepository = goalRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<GoalResponse> DeleteAsync(int id)
        {
            var existingGoal = await _goalRepository.FindByIDAsync(id);

            if (existingGoal == null)
                return new GoalResponse("Goal not found.");

            try
            {
                _goalRepository.Remove(existingGoal);
                await _unitOfWork.CompleteAsync();

                return new GoalResponse(existingGoal);

            }
            catch (Exception ex)
            {
                return new GoalResponse($"An error ocurred while deleting the Goal : {ex.Message}");
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
                await _unitOfWork.CompleteAsync();

                return new GoalResponse(goal);
            }
            catch (Exception ex)
            {

                return new GoalResponse($"An error ocurred while saving the Goal : {ex.Message}");
            }
            throw new NotImplementedException();
        }

        public async Task<GoalResponse> UpdateAsync(int id, Goal goal)
        {
            var existingGoal  = await _goalRepository.FindByIDAsync(id);

            if (existingGoal == null)
                return new GoalResponse("goal not found.");
            existingGoal.Name = goal.Name;
            existingGoal.Description = goal.Description;
            try
            {
                _goalRepository.Update(existingGoal);
                await _unitOfWork.CompleteAsync();

                return new GoalResponse(existingGoal);
            }
            catch (Exception ex)
            {
                return new GoalResponse($"An error ocurred while updating the goal : {ex.Message}");
            }

            throw new NotImplementedException();
        }
    }
}
