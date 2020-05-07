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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingCategory = await _userRepository.FindByIDAsync(id);

            if (existingCategory == null)
                return new UserResponse("Category not found.");

            try
            {
                _userRepository.Remove(existingCategory);

                return new UserResponse(existingCategory);

            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while deleting the category : {ex.Message}");
            }
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);

                return new UserResponse(user);
            }
            catch (Exception ex)
            {

                return new UserResponse($"An error ocurred while saving the category : {ex.Message}");
            }
            throw new NotImplementedException();
        }

        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            var existingCategory = await _userRepository.FindByIDAsync(id);

            if (existingCategory == null)
                return new UserResponse("Category not found.");
            existingCategory.Name = user.Name;
            try
            {
                _userRepository.Update(existingCategory);

                return new UserResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while updating the category : {ex.Message}");
            }

            throw new NotImplementedException();
        }
    }
}
