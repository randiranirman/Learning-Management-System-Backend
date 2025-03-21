using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using UserManagementService.Dtos;
using UserManagementService.Models;
using UserManagementService.Services;

namespace UserManagementService.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        public static User user = new User();
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(UserDto request)
        {
            var user = await authService.RegisterAsync(request);
            if (user is null)
            {
                return BadRequest("Username already exits");
            }


            return Ok(user);
        }



        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> Login(UserDto request)
        {
            var result = await authService.LoginAsync(request);
            if (result is null)
            {
                return BadRequest("Invalid username or password");


            }
            return Ok(result);

        }
        [Authorize]
        [HttpGet]
        public IActionResult AuthenticatedOnly()
        {

            return Ok("You are authenticated");
        }
        [Authorize(Roles = "admin")]
        [HttpGet("admin")]
        public IActionResult AuthenticatedAdminOnly()
        {

            return Ok("You are admin");
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDto
            request)
        {
            var result = await authService.RefreshTokenAsync(request);
            if (result is null || result.AccessToken is null || result.RefreshToken is null)
            {
                return Unauthorized("Invalid refresh token");


            }


            return Ok(result);
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            var username = User.Identity?.Name;
            if (string.IsNullOrEmpty(username))
            {  
                return BadRequest("Invalid username");
            }   
            var result = await authService.LogoutAsync(username);
            if (result)
            {   
                return Ok("Logged out successfully");
            }

            return Ok("Failed to logout");




        }
    }
}
