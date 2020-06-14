using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Domain.Services;
using IdeoGo.API.Domain.Services.Communications;

namespace IdeoGo.API.Services
{
    public class PRojectUserService :IProjectUserService
    {
        private readonly IProjectUserRepository _projectUserRepository;
        private readonly IUnitOfWork _unitOfWork;

        public async Task<ProjectUserResponse> AssignProjectUserAsync(int projectId, int userId)
        {
            try
            {

                await _projectUserRepository.AssignProjectUser(projectId, userId);
                await _unitOfWork.CompleteAsync();
                ProjectUser productTag = await _projectUserRepository.FindByProjectIdAndUserId(projectId, userId);
                return new ProjectUserResponse(productTag);
            }
            catch (Exception ex)
            {
                return new ProjectUserResponse($"An error ocurred while assigning Tag to Product: {ex.Message}");
            }
        }

        public async  Task<IEnumerable<ProjectUser>> ListAsync()
        {
            return await _projectUserRepository.ListAsync();
        }

        public async  Task<IEnumerable<ProjectUser>> ListByProjectIdAsync(int projectId)
        {
            return await _projectUserRepository.ListByProjectIdAsync(projectId);
        }

        public async Task<IEnumerable<ProjectUser>> ListByUserIdAsync(int userId)
        {
            return await _projectUserRepository.ListByUserIdAsync(userId);
        }

        public async  Task<ProjectUserResponse> UnassignProjectUserAsync(int projectId, int userId)
        {
            try
            {
                ProjectUser projectUser = await _projectUserRepository.FindByProjectIdAndUserId(projectId, userId);
                _projectUserRepository.Remove(projectUser);
                await _unitOfWork.CompleteAsync();
                return new ProjectUserResponse(projectUser);
            }
            catch (Exception ex)
            {
                return new ProjectUserResponse($"An error ocurred while assigning Tag to Product: {ex.Message}");
            }

        }
    }
}
