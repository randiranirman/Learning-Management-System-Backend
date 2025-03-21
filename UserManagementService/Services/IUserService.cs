using UserManagementService.Dtos;
using UserManagementService.Models;

namespace UserManagementService.Services
{
    public interface IUserService
    {

        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task<bool> DeleteUserById( int id );



    }
}
