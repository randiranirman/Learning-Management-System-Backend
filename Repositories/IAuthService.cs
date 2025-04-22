using Microsoft.AspNetCore.Mvc;
using UserManagementService.Dtos;
using UserManagementService.Models;

namespace UserManagementService.Repositories
{
    public interface IAuthService
    {
        Task<UserDto?> RegisterAsync(UserDto request);
        Task<TokenResponseDto?> LoginAsync(UserDto request);
        Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto request);
        Task<bool> LogoutAsync(string username);
        Task<bool> IsFirstLogin(UserDto request);
        Task<bool> UpdateFirstLoginStatus(UserDto request);

        Task<bool> ChangeCredentials(String username, ChangeCredentialsDto request);


    }
}
