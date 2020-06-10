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
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;


        public TagService(ITagRepository tagRepository, IUnitOfWork unitOfWork)
        {
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TagResponse> DeleteAsync(int id)
        {
            var existingCategory = await _tagRepository.FindByIDAsync(id);

            if (existingCategory == null)
                return new TagResponse("Category not found.");

            try
            {
                _tagRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new TagResponse(existingCategory);

            }
            catch (Exception ex)
            {
                return new TagResponse($"An error ocurred while deleting the category : {ex.Message}");
            }
        }

        public async Task<IEnumerable<Tag>> ListAsync()
        {
            return await _tagRepository.ListAsync();
        }

        public async Task<IEnumerable<Tag>> ListByCategoryIdAsync(int categoryId)
        {
            return await _tagRepository.ListByCategoryIdAsync(categoryId);
        }

        public async Task<TagResponse> SaveAsync(Tag tag)
        {
            try
            {
                await _tagRepository.AddAsync(tag);
                await _unitOfWork.CompleteAsync();
                return new TagResponse(tag);
            }
            catch (Exception ex)
            {

                return new TagResponse($"An error ocurred while saving the category : {ex.Message}");
            }
            throw new NotImplementedException();
        }

        public async Task<TagResponse> UpdateAsync(int id, Tag tag)
        {
            var existingCategory = await _tagRepository.FindByIDAsync(id);

            if (existingCategory == null)
                return new TagResponse("Category not found.");
            existingCategory.Name = tag.Name;
            try
            {
                _tagRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();
                return new TagResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new TagResponse($"An error ocurred while updating the category : {ex.Message}");
            }

            throw new NotImplementedException();
        }
    }
}
