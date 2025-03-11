using CourseManagementService.Data;
using CourseManagementService.Models.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementService.Repositories
{
    public class SQLTeacherRepository : ITeacherRepository
    {
        private readonly LmsContext _context;

        public SQLTeacherRepository(LmsContext Context)
        {
            _context = Context;
        }
        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _context.Teachers.ToListAsync();
        }
    }
}
