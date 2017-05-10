using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Models.DTO;
using Models.Requests;
using Models.Responses;
using QuestPlatform.Domain.Infrastructure.Contracts;
using QuestPlatform.Domain.Infrastructure.Repositories;
using QuestPlatform.Services.Contracts;
using Store.Models;

namespace QuestPlatform.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserService(UserManager<ApplicationUser> manager) : this(new UserRepository(manager))
        {
            
        }

        public async Task<UserRegistrationResponse> CreateAsync(UserRegistrationRequest model)
        {
            var checkIsUserAlreadyExistWithEmail = await _userRepository.GetUserAsync(model.Email);
            if (checkIsUserAlreadyExistWithEmail != null)
            {
                return new UserRegistrationResponse(false, "User email is already exist");
            }

            // Create user
            var user = new ApplicationUser()
            {
                UserName = model.Email,
                Email = model.Email
            };
            await _userRepository.CreateAsync(user, model.Password);
            // Return result
            return new UserRegistrationResponse(true, "Succeded!");
        }

        public async Task<ApplicationUser> FindByIdAsync(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                return null;
            }
            return await _userRepository.GetUserById(id);
        }

        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            if (String.IsNullOrWhiteSpace(email))
            {
                return null;
            }
            return await _userRepository.GetUserAsync(email);
        }

        public async Task<ChangePasswordResponse> ChangePasswordAsync(ChangePasswordRequest request)
        {
            if (String.IsNullOrWhiteSpace(request.UserId))
            {
                return ChangePasswordResponse.Fail("UserId wasn't initialized!");
            }

            if (request.OldPassword.Equals(request.NewPassword))
            {
                return ChangePasswordResponse.Fail("New and old passwords must be different!");
            }

            if (!request.NewPassword.Equals(request.ConfirmPassword))
            {
                return ChangePasswordResponse.Fail("ConfirmPassword and NewPassword was not equals");
            }

            var result = await _userRepository.EditPassword(request.UserId,
                request.OldPassword, request.NewPassword);
            // Check result and return response
            return result.Succeeded ? ChangePasswordResponse.Success()
                                    : ChangePasswordResponse.Fail(result.Errors.FirstOrDefault());
        }

        public async Task<ChangePasswordResponse> SetPasswordAsync(SetPasswordRequest request)
        {
            if (request == null)
            {
                return ChangePasswordResponse.Fail("Bad request");
            }
            if (!request.NewPassword.Equals(request.ConfirmPassword))
            {
                return ChangePasswordResponse.Fail("Passwords was not equal");
            }

            var result = await _userRepository.SetPassword(request.UserId, request.NewPassword);
            return result.Succeeded ? ChangePasswordResponse.Success()
                                    : ChangePasswordResponse.Fail(result.Errors.FirstOrDefault());
        }

        public async Task<AddExternalLoginResponse> AddExternalLoginAsync(AddExternalLoginRequest request)
        {
            if (request.LoginInfo == null)
            {
                return new AddExternalLoginResponse()
                {
                    Succeded = false,
                    Message = "Login info was not initialize"
                };
            }
            var result = await _userRepository.AddLoginAsync(request.UserId, request.LoginInfo);
            return new AddExternalLoginResponse()
            {
                Succeded = result.Succeeded,
                Message = result.Errors.FirstOrDefault() ?? String.Empty
            };
        }
    }
}
