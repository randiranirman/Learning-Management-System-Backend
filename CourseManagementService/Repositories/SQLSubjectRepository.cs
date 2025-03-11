using CourseManagementService.Data;
using CourseManagementService.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementService.Repositories
{
    public class SQLSubjectRepository : ISubjectRepository
    {
        private readonly LmsContext _context;
        public SQLSubjectRepository(LmsContext context)
        {
            _context = context;
        }

        public async Task<List<Subject>> GetSubjectAsync()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<Subject> CreateSubjectAsync(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();

            return subject;
        }
    }
}
