using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagementService.Data;
using UserManagementService.Models;
using UserManagementService.Repositories;

namespace UserManagementService.Services
{
    public class AdminService(UserDbcontext _context) : IAdminService
    {
        public async Task<bool> EditAdminDetails(int id, Admin request)
        {
            

            var admin = await _context.Admins.FindAsync(id);

            if( admin == null)
            {
                return false;
            }
            admin.FirstName = request.FirstName;
            admin.Address = request.Address;
            admin.LastName = request.LastName;
            admin.ContactNumber = request.ContactNumber;

            await _context.SaveChangesAsync();
            return true;


        }


        public async Task<IEnumerable<Admin>> GetAllAdmins()
        {
            var admins = await _context.Admins.ToListAsync();
            return admins;



            
            
        }

        public async Task<Admin> GetAdminDetails(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            
            if( admin == null)
            {
                return null;
            }
            return admin;
        }
    }
}
