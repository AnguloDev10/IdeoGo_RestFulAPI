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
    public class ResourceService : IResourceService
    {

        private readonly IResourceRepository _resourceRepository;
        public readonly IUnitOfWork _unitOfWork;

        public ResourceService(IResourceRepository resourceRepository, IUnitOfWork unitOfWork)
        {
            _resourceRepository = resourceRepository;
            _unitOfWork = unitOfWork;
        }

        public ResourceService(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public async Task<ResourceResponse> DeleteAsync(int id)
        {
            var existingResource = await _resourceRepository.FindByIdAsync(id);

            if (existingResource == null)
                return new ResourceResponse("resource not found.");

            try
            {
                _resourceRepository.Remove(existingResource);


                return new ResourceResponse(existingResource);

            }
            catch (Exception ex)
            {
                return new ResourceResponse($"An error ocurred while deleting the resource : {ex.Message}");
            }
        }

        public async Task<IEnumerable<Resource>> ListAsync()
        {
            return await _resourceRepository.ListAsync();
        }

        public async Task<ResourceResponse> SaveAsync(Resource resource)
        {
            try
            {
                await _resourceRepository.AddAsync(resource);

                return new ResourceResponse(resource);
            }
            catch (Exception ex)
            {

                return new ResourceResponse($"An error ocurred while saving the resource : {ex.Message}");
            }
            throw new NotImplementedException();
        }

        public async Task<ResourceResponse> UpdateAsync(int id, Resource resource)
        {
            var existingResource = await _resourceRepository.FindByIdAsync(id);

            if (existingResource == null)
                return new ResourceResponse("Resource not found.");
            existingResource.Id = resource.Id;
            try
            {
                _resourceRepository.Update(existingResource);

                return new ResourceResponse(existingResource);
            }
            catch (Exception ex)
            {
                return new ResourceResponse($"An error ocurred while updating the resource : {ex.Message}");
            }

            throw new NotImplementedException();
        }
    }
}
