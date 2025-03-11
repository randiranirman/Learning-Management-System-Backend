using CourseManagementService.Models.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace CourseManagementService.Repositories
{
    public interface ITeacherRepository
    {
        public Task<List<Teacher>> GetAllAsync();
    }
}
