using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Domain.Services;
using IdeoGo.API.Domain.Services.Communications;
using IdeoGo.API.Persistence.Repositories;

namespace IdeoGo.API.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationRepository _applicationRepository;
        private readonly IProjectUserRepository _projectUserRepository;

        

        public ProjectService(IProjectRepository projectRepository, IUnitOfWork unitOfWork,
            IApplicationRepository applicationRepository, IProjectUserRepository projectUserRepository)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
            _applicationRepository = applicationRepository;
            _projectUserRepository = projectUserRepository;
        }

        public async Task<ProjectResponse> DeleteAsync(int id)
        {
            var existingProject = await _projectRepository.FindById(id);

            if (existingProject == null)
                return new ProjectResponse("Project not found");

            try
            {
                _projectRepository.Remove(existingProject);
                await _unitOfWork.CompleteAsync();

                return new ProjectResponse(existingProject);
            }
            catch (Exception ex)
            {
                return new ProjectResponse($"An error ocurred while deleting project: {ex.Message}");
            }
        }

        public async Task<ProjectResponse> GetByIdAsync(int id)
        {
            var existingProject = await _projectRepository.FindById(id);

            if (existingProject == null)
                return new ProjectResponse("Project not found");
            return new ProjectResponse(existingProject);
        }

        public async Task<IEnumerable<Project>> ListAsync()
        {
           
              return  await _projectRepository.ListAsync();
        }

        public async Task<ProjectResponse> SaveAsync(Project project)
        {
            try
            {
                await _projectRepository.AddAsync(project);
                await _unitOfWork.CompleteAsync();

                return new ProjectResponse(project);
            }
            catch (Exception ex)
            {
                return new ProjectResponse($"An error ocurred while saving the project: {ex.Message}");
            }
        }

        public async Task<ProjectResponse> UpdateAsync(int id, Project project)
        {
            var existingProject = await _projectRepository.FindById(id);

            if (existingProject == null)
                return new ProjectResponse("Project not found");

            existingProject.Name = project.Name;
            existingProject.Description = project.Description;
            existingProject.DateCreated = project.DateCreated;

            try
            {
                _projectRepository.Update(existingProject);
                await _unitOfWork.CompleteAsync();

                return new ProjectResponse(existingProject);
            }
            catch (Exception ex)
            {
                return new ProjectResponse($"An error ocurred while updating project: {ex.Message}");
            }
        }
        // implementar
        public async Task<IEnumerable<Project>> ListByApplicationUserIdAsync(int appUserId)
        {
            var applications = await _applicationRepository.ListByUserIdAsync(appUserId);
            var projects = applications.Select(pt => pt.Project).ToList();
            return projects;
        }
        //implementar
        public async Task<IEnumerable<Project>> ListByProjectLeaderIdAsync(int projectLeaderId)
        {
            return await _projectRepository.ListByProjectLeaderIdAsync(projectLeaderId);
        }

        public async Task<IEnumerable<Project>> ListByProjectUserByUserIdAsync(int userId)
        {
            var projectUsers = await _projectUserRepository.ListByUserIdAsync(userId);
            var projects = projectUsers.Select(pt => pt.Project).ToList();
            return projects;


        }

        public async Task<IEnumerable<Project>> ListByTagName(string tag)
        {
            return await _projectRepository.ListBytagName(tag);
        }


        public async Task<ProjectResponse> AssignProjectLeaderAsync(int projectId, int userId)
        {
            try
            {
                await _projectRepository.AssignProjectLeader(projectId, userId);
                await _unitOfWork.CompleteAsync();
                Project project = await _projectRepository.FindById(projectId);
                return new ProjectResponse(project);
            }
            catch (Exception ex)
            {
                return new ProjectResponse($"An error ocurred while assigning: {ex.Message}");
            }
        }

        public async Task<ProjectResponse> UnassignProjectLeaderAsync(int projectId, int userId)
        {
            try
            {
                Project project = await _projectRepository.FindById(projectId);
                _projectRepository.Remove(project);
                await _unitOfWork.CompleteAsync();
                return new ProjectResponse(project);
            }
            catch (Exception ex)
            {
                return new ProjectResponse($"An error ocurred while assigning: {ex.Message}");
            }
        }

        public async Task<ProjectResponse> AssignProjectTagAsync(int projectId, int tagId)
        {
            try
            {
                await _projectRepository.AssignProjectTag(projectId, tagId);
                await _unitOfWork.CompleteAsync();
                Project project = await _projectRepository.FindById(projectId);
                return new ProjectResponse(project);
            }
            catch (Exception ex)
            {
                return new ProjectResponse($"An error ocurred while assigning: {ex.Message}");
            }
        }

        public async Task<ProjectResponse> UnassignProjectTagAsync(int projectId, int tagId)
        {
            try
            {
                Project project = await _projectRepository.FindById(projectId);
                _projectRepository.Remove(project);
                await _unitOfWork.CompleteAsync();
                return new ProjectResponse(project);
            }
            catch (Exception ex)
            {
                return new ProjectResponse($"An error ocurred while assigning: {ex.Message}");
            }
        }
    }
}
