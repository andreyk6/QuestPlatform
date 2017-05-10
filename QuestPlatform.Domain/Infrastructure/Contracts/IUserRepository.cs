using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Store.Models;

namespace QuestPlatform.Domain.Infrastructure.Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
        Task<ApplicationUser> GetUserByNameAsync(string username);
        Task EditAsync(ApplicationUser user);
        Task<IdentityResult> EditPassword(string userId, string oldPassword, string newPassword);
        Task<IdentityResult> SetPassword(string userId, string newPassword);
        Task<ApplicationUser> GetUserAsync(string userEmail);
        Task<ApplicationUser> GetUserById(string userId);

        Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login);
    }
}
