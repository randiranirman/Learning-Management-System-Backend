using Microsoft.AspNetCore.Mvc;
using UserManagementService.Models;

namespace UserManagementService.Repositories
{
    public interface IAdminService
    {

        public Task<bool> EditAdminDetails(int id , Admin request);
        public Task<IEnumerable<Admin>> GetAllAdmins();
        public Task<Admin> GetAdminDetails(int id);


    }
}
