using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Domain.Services;
using IdeoGo.API.Domain.Services.Communication;
using IdeoGo.API.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace IdeoGo.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProjectUserRepository _projectUserRepository;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingUser = await _userRepository.FindById(id);

            if (existingUser == null)
                return new UserResponse("User not found.");

            try
            {
                _userRepository.Remove(existingUser);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(existingUser);

            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while deleting the user : {ex.Message}");
            }
        }

        public async Task<UserResponse> GetByIdAsync(int id)
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

        public async Task<IEnumerable<User>> ListByProjectIdAsync(int projectId)
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
                await _unitOfWork.CompleteAsync();
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
                await _unitOfWork.CompleteAsync();
                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while updating the user : {ex.Message}");
            }

            throw new NotImplementedException();
        }


        /// ////////

        private List<User> _users = new List<User>
        {
            new User
            {
                Id = 1,
                Email = "correo@gmail.com", Datesignup = new DateTime(2020, 5, 1, 8, 30, 52), Password = "1234"
            }
        };

        private readonly AppSettings _appSettings;



        public AuthenticateResponse Authenticate(AuthenticateRequest request)
        {
            var user = _users.SingleOrDefault(x =>
           x.Email == request.Email &&
           x.Password == request.Password);

            //return null when user not found
            if (user == null) return null;

            // user found, so generte jwt token
            var token = GenerateJwtToken(user);


            return new AuthenticateResponse(user, token);
        }


        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}
