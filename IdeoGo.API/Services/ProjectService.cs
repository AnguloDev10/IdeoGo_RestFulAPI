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
        public ProjectService(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
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
                return new ProjectResponse($"An error ocurred while deleting guardian: {ex.Message}");
            }
        }

        public async Task<ProjectResponse> GetByIdAsync(int id)
        {
            var existingProject = await _projectRepository.FindById(id);

            if (existingProject == null)
                return new ProjectResponse("Project not found");
            return new ProjectResponse(existingProject);
        }

        public  async Task<IEnumerable<Project>> ListAsync()
        {
            return await _projectRepository.ListAsync();
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
                return new ProjectResponse($"An error ocurred while saving the guardian: {ex.Message}");
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
                return new ProjectResponse($"An error ocurred while updating guardian: {ex.Message}");
            }
        }
    }
}
