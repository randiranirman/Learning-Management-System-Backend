using UserManagementService.Dtos;
using UserManagementService.Models;

namespace UserManagementService.Services
{
    public interface IAuthService
    {
        Task<UserDto?> RegisterAsync(UserDto request);
        Task<TokenResponseDto?> LoginAsync(UserDto request);
        Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto request);
        Task<bool> LogoutAsync(string username);


    }
}
