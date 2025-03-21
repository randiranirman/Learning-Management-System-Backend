using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using UserManagementService.Data;
using UserManagementService.Dtos;
using UserManagementService.Models;

namespace UserManagementService.Services
{
    public class UserService : IUserService
    {
        private readonly UserDbcontext _context;
        public UserService(UserDbcontext context)
        {
            _context = context;
            
        }
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();

            return users.Select(user => new UserDto
            {
                Name = user.Name,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            }).ToList();
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return null; ;  
            }

            return new UserDto
            {
                Name = user.Name,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            };
        }

        public  async Task<bool> DeleteUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);


            if ( user == null)
            {
                return false;

            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

       
    }
}
