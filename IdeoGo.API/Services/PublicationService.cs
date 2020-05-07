using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IPublicationRespository _publicationRepository;
        public async Task<PublicationResponse> DeleteAsync(int id)
        {
            var existingCategory = await _publicationRepository.FindByIDAsync(id);

            if (existingCategory == null)
                return new PublicationResponse("Category not found.");

            try
            {
                _publicationRepository.Remove(existingCategory);

                return new PublicationResponse(existingCategory);

            }
            catch (Exception ex)
            {
                return new PublicationResponse($"An error ocurred while deleting the category : {ex.Message}");
            }
        }

        public async Task<IEnumerable<Publication>> ListAsync()
        {
            return await _publicationRepository.ListAsync();
        }

        public async Task<PublicationResponse> SaveAsync(Publication publication)
        {
            try
            {
                await _publicationRepository.AddAsync(publication);

                return new PublicationResponse(publication);
            }
            catch (Exception ex)
            {

                return new PublicationResponse($"An error ocurred while saving the category : {ex.Message}");
            }
            throw new NotImplementedException();
        }

        public async Task<PublicationResponse> UpdateAsync(int id, Publication publication)
        {
            var existingCategory = await _publicationRepository.FindByIDAsync(id);

            if (existingCategory == null)
                return new PublicationResponse("Category not found.");
            existingCategory.Title= publication.Title;
            existingCategory.Description = publication.Description;
            existingCategory.Body = publication.Body;
            existingCategory.CreateAt = publication.CreateAt;
            try
            {
                _publicationRepository.Update(existingCategory);
          
                return new PublicationResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new PublicationResponse($"An error ocurred while updating the category : {ex.Message}");
            }

            throw new NotImplementedException();
        }
    }
}
