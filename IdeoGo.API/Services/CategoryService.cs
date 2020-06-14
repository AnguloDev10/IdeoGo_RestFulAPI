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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public readonly IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var existingCategory = await _categoryRepository.FindByIDAsync(id);

            if (existingCategory == null)
                return new CategoryResponse("Category not found.");

            try
            {
                _categoryRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);

            }
            catch (Exception ex)
            {
                return new CategoryResponse($"An error ocurred while deleting the category : {ex.Message}");
            }
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
           return await _categoryRepository.ListAsync();
        }

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(category);
            }
            catch (Exception ex)
            {

                return new CategoryResponse($"An error ocurred while saving the category : {ex.Message}");
            }
            throw new NotImplementedException();
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _categoryRepository.FindByIDAsync(id);

            if (existingCategory == null)
                return new CategoryResponse("Category not found.");
            existingCategory.Name = category.Name;
            try
            {
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"An error ocurred while updating the category : {ex.Message}");
            }

            throw new NotImplementedException();
        }


    }
}
