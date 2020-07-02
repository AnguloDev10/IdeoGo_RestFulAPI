using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Domain.Services;
using IdeoGo.API.Domain.Services.Communication;
using IdeoGo.API.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        public readonly IUnitOfWork _unitOfWork;

        public ApplicationService(IApplicationRepository applicationRepository, IUnitOfWork unitOfWork)
        {
            _applicationRepository = applicationRepository;
            _unitOfWork = unitOfWork;
        }

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<ApplicationResponse> DeleteAsync(int id)
        {
            var existingApplication = await _applicationRepository.FindByIDAsync(id);

            if (existingApplication == null)
                return new ApplicationResponse("application not found.");

            try
            {
                _applicationRepository.Remove(existingApplication);
                await _unitOfWork.CompleteAsync();

                return new ApplicationResponse(existingApplication);

            }
            catch (Exception ex)
            {
                return new ApplicationResponse($"An error ocurred while deleting the application : {ex.Message}");
            }
        }

        public async Task<IEnumerable<Application>> ListAsync()
        {
            return await _applicationRepository.ListAsync();
        }

        public async Task<ApplicationResponse> SaveAsync(Application application)
        {
            try
            {
                await _applicationRepository.AddAsync(application);
                await _unitOfWork.CompleteAsync();
                return new ApplicationResponse(application);
            }
            catch (Exception ex)
            {

                return new ApplicationResponse($"An error ocurred while saving the application : {ex.Message}");
            }
            throw new NotImplementedException();
        }

        public async Task<ApplicationResponse> UpdateAsync(int id, Application application)
        {
            var existingApplication = await _applicationRepository.FindByIDAsync(id);

            if (existingApplication == null)
                return new ApplicationResponse("Category not found.");
            existingApplication.OrderRequest = application.OrderRequest;
            try
            {
                _applicationRepository.Update(existingApplication);
                await _unitOfWork.CompleteAsync();
                return new ApplicationResponse(existingApplication);
            }
            catch (Exception ex)
            {
                return new ApplicationResponse($"An error ocurred while updating the application : {ex.Message}");
            }

            throw new NotImplementedException();
        }



        public async Task<ApplicationResponse> AssignApplicationProjectAsync(int applicationId, int projectId)
        {
            try
            {

                await _applicationRepository.AssignApplicationProject(applicationId, projectId);
                await _unitOfWork.CompleteAsync();
                Application application = await _applicationRepository.FindByIDAsync(applicationId);
                return new ApplicationResponse(application);
            }
            catch (Exception ex)
            {
                return new ApplicationResponse($"An error ocurred while assigning: {ex.Message}");
            }
        }

        public async Task<ApplicationResponse> UnassignApplicationProjectAsync(int applicationId, int projectId)
        {
            try
            {
                Application application = await _applicationRepository.FindByIDAsync(applicationId);
                _applicationRepository.Remove(application);
                await _unitOfWork.CompleteAsync();
                return new ApplicationResponse(application);
            }
            catch (Exception ex)
            {
                return new ApplicationResponse($"An error ocurred while assigning: {ex.Message}");
            }
        }

        public async Task<ApplicationResponse> AssignApplicationUserAsync(int applicationId, int userId)
        {
            try
            {

                await _applicationRepository.AssignApplicationUser(applicationId, userId);
                await _unitOfWork.CompleteAsync();
                Application application = await _applicationRepository.FindByIDAsync(applicationId);
                return new ApplicationResponse(application);
            }
            catch (Exception ex)
            {
                return new ApplicationResponse($"An error ocurred while assigning: {ex.Message}");
            }
        }

        public async Task<ApplicationResponse> UnassignApplicationUserAsync(int applicationId, int userId)
        {
            try
            {
                Application application = await _applicationRepository.FindByIDAsync(applicationId);
                _applicationRepository.Remove(application);
                await _unitOfWork.CompleteAsync();
                return new ApplicationResponse(application);
            }
            catch (Exception ex)
            {
                return new ApplicationResponse($"An error ocurred while assigning: {ex.Message}");
            }
        }
    }
   }
