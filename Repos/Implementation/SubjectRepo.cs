using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repos.Interfaces;

namespace SchoolManagementSystem.Repos.Implementation
{
    public class SubjectRepo : GenericRepo<Subject>, ISubjectRepo
    {
        public SubjectRepo(AppDbContext db, DbSet<Subject> dbset) : base(db, dbset)
        {
        }

        public async Task<Subject> GetSubject(int id)
        {
            return await db.Subjects
                           .Include(x => x.StudentSubjects)
                           .ThenInclude(x => x.Student)
                           .FirstOrDefaultAsync(x=> x.Id == id);
        }


        public async Task<List<Subject>> GetSubjects()
        {
            return await db.Subjects
                           .Include(x => x.StudentSubjects)
                           .ThenInclude(x => x.Student)
                           .ToListAsync();
        }

    }
}
