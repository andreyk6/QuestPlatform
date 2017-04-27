using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Models;

namespace QuestPlatform.Domain.Infrastructure.Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        Task CreateAsync(ApplicationUser user, string password);
        Task<ApplicationUser> GetUserByNameAsync(string username);
        Task EditAsync(ApplicationUser user);
        Task<ApplicationUser> GetUserAsync(string userEmail);
        Task<ApplicationUser> GetUserById(string userId);
    }
}
