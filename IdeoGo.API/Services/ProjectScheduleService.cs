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
    public class ProjectScheduleService : IProjectScheduleService
    {
        private readonly IProjectScheduleRepository _projectScheduleRepository;
        public readonly IUnitOfWork _unitOfWork;

        public ProjectScheduleService(IProjectScheduleRepository projectScheduleRepository, IUnitOfWork unitOfWork)
        {
            _projectScheduleRepository = projectScheduleRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ProjectScheduleResponse> DeleteAsync(int id)
        {
            var existingProjectSchedule = await _projectScheduleRepository.FindById(id);

            if (existingProjectSchedule == null)
                return new ProjectScheduleResponse("ProjectSchedule not found.");

            try
            {
                _projectScheduleRepository.Remove(existingProjectSchedule);


                return new ProjectScheduleResponse(existingProjectSchedule);
            }
            catch (Exception ex)
            {
                return new ProjectScheduleResponse($"An error ocurred while deleting the ProjectSchedule : {ex.Message}");
            }
        }

        public async Task<ProjectScheduleResponse> GetByIdAsync(int id)
        {
            var existingProjectSchedule = await _projectScheduleRepository.FindById(id);

            if (existingProjectSchedule == null)
                return new ProjectScheduleResponse("ProjectSchedule not found");
            return new ProjectScheduleResponse(existingProjectSchedule);
        }

        public async Task<IEnumerable<ProjectSchedule>> ListAsync()
        {
            return await _projectScheduleRepository.ListAsync();
        }

        public async Task<ProjectScheduleResponse> SaveAsync(ProjectSchedule projectSchedule)
        {
            try
            {
                await _projectScheduleRepository.AddAsync(projectSchedule);

                return new ProjectScheduleResponse(projectSchedule);
            }
            catch (Exception ex)
            {
                return new ProjectScheduleResponse($"An error ocurred while saving the ProjectSchedule: {ex.Message}");
            }
        }

        public async Task<ProjectScheduleResponse> UpdateAsync(int id, ProjectSchedule projectSchedule)
        {
            var existingProjectSchedule = await _projectScheduleRepository.FindById(id);

            if (existingProjectSchedule == null)
                return new ProjectScheduleResponse("ProjectSchedule not found");

            existingProjectSchedule.Name = projectSchedule.Name;

            try
            {
                _projectScheduleRepository.Update(existingProjectSchedule);

                return new ProjectScheduleResponse(existingProjectSchedule);
            }
            catch (Exception ex)
            {
                return new ProjectScheduleResponse($"An error ocurred while updating ProjectSchedule: {ex.Message}");
            }
        }
    }
}
