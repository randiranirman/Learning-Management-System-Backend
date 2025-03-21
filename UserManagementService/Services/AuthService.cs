using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UserManagementService.Data;
using UserManagementService.Dtos;
using UserManagementService.Models;

namespace UserManagementService.Services
{
    public class AuthService(UserDbcontext context, IConfiguration configuration) : IAuthService
    {
            public async Task<TokenResponseDto> LoginAsync(UserDto request)
            {   
                var user = await context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
                if (user is null)
                {
                    return null;

                }






                if (new PasswordHasher<User>().VerifyHashedPassword(user, user.hashedPassword, request.Password) == PasswordVerificationResult.Failed)

                {
                    return null;
                }

                TokenResponseDto response = await CreateTokenResponse(user);

                return response;


            }

            private async Task<TokenResponseDto> CreateTokenResponse(User? user)
            {
                        if(user is null)
            {
                return null;
            }   
            return new TokenResponseDto
                {
                    AccessToken = CreateToken(user),
                    RefreshToken = await GenerateAndSaveRefreshToken(user)

                };
            }

        public async Task<UserDto?> RegisterAsync(UserDto request)
        {
            if (await context.Users.AnyAsync(u => u.Username == request.Username))
            {
                return null;
            }
            var user = new User();
            var hashedPassword = new PasswordHasher<User>().HashPassword(user, request.Password);

            user.Username = request.Username;
            user.hashedPassword = hashedPassword;
            user.Email= request.Email;
            user.Name= request.Name;
            user.Role= request.Role;

            context.Users.Add(user);
            await context.SaveChangesAsync();



            return new UserDto
            {
                Username = request.Username,
                Name = request.Name,
                Role = request.Role,
                Email = request.Email
                    

            };
        }



        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };


            var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDesciptor = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds


                );


            return new JwtSecurityTokenHandler().WriteToken(tokenDesciptor);


        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new Byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        private async Task<string> GenerateAndSaveRefreshToken(User user)
        {
            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            context.Users.Update(user); // Explicitly update the entity
            await context.SaveChangesAsync();

            return refreshToken;
        }
    

        private async Task<User?> ValidateRefreshTokenAsync(int  userId, string refreshToken)
        {
            var user = await context.Users.SingleOrDefaultAsync(u => u.Id == userId && u.RefreshToken== refreshToken);
            if (user is null || user.RefreshTokenExpiryTime < DateTime.UtcNow)
            {
                return null;
            }

            return user;






        }

        public async Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto request)
        {
            var user = await ValidateRefreshTokenAsync(request.UserId, request.RefreshToken);
            if (user  is null)
            {
                return null;
            }

            return await CreateTokenResponse(user);
                
        }

        public async Task<bool> LogoutAsync(string username)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user is null)
            {
                return false;
            }
            user.RefreshToken = null;
            user.RefreshTokenExpiryTime = null;
            context.Users.Update(user);
            await context.SaveChangesAsync();
            return true;
        }

        
    }   
}
