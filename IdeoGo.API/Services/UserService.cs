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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProjectUserRepository _projectUserRepository;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingUser = await _userRepository.FindById(id);

            if (existingUser == null)
                return new UserResponse("User not found.");

            try
            {
                _userRepository.Remove(existingUser);

                return new UserResponse(existingUser);

            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while deleting the category : {ex.Message}");
            }
        }

        public async  Task<UserResponse> GetByIdAsync(int id)
        {
            var existingUser = await _userRepository.FindById(id);

            if (existingUser == null)
                return new UserResponse("User not found");
            return new UserResponse(existingUser);

        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public  async Task<IEnumerable<User>> ListByProjectIdAsync(int projectId)
        {
            var projectUsers = await _projectUserRepository.ListByProjectIdAsync(projectId);
            var users = projectUsers.Select(pt => pt.User).ToList();
            return users;
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

                return new UserResponse($"An error ocurred while saving the user : {ex.Message}");
            }
            throw new NotImplementedException();
        }

        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            var existingUser = await _userRepository.FindById(id);

            if (existingUser == null)
                return new UserResponse("User not found.");
            
            existingUser.Email = user.Email;
            existingUser.Datesignup = user.Datesignup;
            existingUser.Password = user.Password;
            try
            {
                _userRepository.Update(existingUser);

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while updating the user : {ex.Message}");
            }

            throw new NotImplementedException();
        }
    }
}
