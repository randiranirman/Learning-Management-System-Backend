using CourseManagementService.Data;
using CourseManagementService.Models.Domains;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<Subject?> DeleteSubjectAsync(Guid Code)
        {
            var existingSubject = await _context.Subjects.FirstOrDefaultAsync(subject => subject.Code == Code);

            if (existingSubject is null)
                return null;

            _context.Remove(existingSubject);
            await _context.SaveChangesAsync();

            return existingSubject;
        }

        public async Task<Subject?> UpdateSubjectAsync(Guid Code, Subject updatedSubject)
        {
            var existingSubject = await _context.Subjects.FirstOrDefaultAsync(subject => subject.Code == Code);

            if (existingSubject is null)
                return null;

            existingSubject.Title = updatedSubject.Title;
            existingSubject.Grade = updatedSubject.Grade;

            await _context.SaveChangesAsync();

            return existingSubject;
        }
    }
}
