using Microsoft.EntityFrameworkCore;
using UserManagementService.Models;

namespace UserManagementService.Data
{
    public class UserDbcontext(DbContextOptions<UserDbcontext> options) :DbContext(options)
    {
        public  DbSet<User> Users { get; set; }

    }
}
