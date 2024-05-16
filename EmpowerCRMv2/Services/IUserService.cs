using EmpowerCRMv2.Data;
using Microsoft.AspNetCore.Identity;

namespace EmpowerCRMv2.Services
{
    public interface IUserService
    {
        Task<List<ApplicationUser>> GetAllUsersAsync();
        Task<List<IdentityRole>> GetAllRolesAsync();
        Task EditUserRoleAsync(string userId, string newRole);
        Task<bool> ChangeUserPasswordAsync(string userId, string newPassword);
        Task DeleteUserAsync(string userId);
        Task<IList<string>> GetUserRoleAsync(string userId);
    }
}
