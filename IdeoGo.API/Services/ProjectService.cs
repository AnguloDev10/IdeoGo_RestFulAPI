using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public async Task<ProjectResponse> DeleteAsync(int id)
        {
            var existingCategory = await _projectRepository.FindByIDAsync(id);

            if (existingCategory == null)
                return new ProjectResponse("Category not found.");

            try
            {
                _projectRepository.Remove(existingCategory);

                return new ProjectResponse(existingCategory);

            }
            catch (Exception ex)
            {
                return new ProjectResponse($"An error ocurred while deleting the category : {ex.Message}");
            }
        }

        public async Task<IEnumerable<Project>> ListAsync()
        {
            return await _projectRepository.ListAsync();
        }

        public async Task<ProjectResponse> SaveAsync(Project project)
        {

            try
            {
                await _projectRepository.AddAsync(project);

                return new ProjectResponse(project);
            }
            catch (Exception ex)
            {

                return new ProjectResponse($"An error ocurred while saving the category : {ex.Message}");
            }
            throw new NotImplementedException();
        }

        public async Task<ProjectResponse> UpdateAsync(int id, Project project)
        {
            var existingCategory = await _projectRepository.FindByIDAsync(id);

            if (existingCategory == null)
                return new ProjectResponse("Category not found.");
            existingCategory.Name = project.Name;
            existingCategory.Description = project.Description;
            try
            {
                _projectRepository.Update(existingCategory);

                return new ProjectResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new ProjectResponse($"An error ocurred while updating the category : {ex.Message}");
            }

            throw new NotImplementedException();
        }
    }
}
