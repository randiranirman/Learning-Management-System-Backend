using UserManagementService.Dtos;
using UserManagementService.Models;

namespace UserManagementService.Repositories
{
    public interface IUserService
    {

        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task<bool> DeleteUserAsync(string username);
        Task<bool> DeleteUserByIdAsync(int id);


    }
}
