using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DTO;
using Models.Requests;
using Models.Responses;
using Store.Models;

namespace QuestPlatform.Services.Contracts
{
    public interface IUserService
    {
        Task<UserRegistrationResponse> CreateAsync(UserRegistrationRequest model);
        Task<ApplicationUser> FindByIdAsync(string id);
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<ChangePasswordResponse> ChangePasswordAsync(ChangePasswordRequest request);
        Task<ChangePasswordResponse> SetPasswordAsync(SetPasswordRequest request);
        Task<AddExternalLoginResponse> AddExternalLoginAsync(AddExternalLoginRequest request);
    }
}
