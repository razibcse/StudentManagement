
using Models;

namespace DataAccess.Repository
{
    public class EnrollmentRepository:IEnrollmentRepository
    {

        private readonly ApplicationDbContext _context;
        public EnrollmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddStudentWithCourses(int studentId, int[] courseList)
        {
            for(int i = 0; i < courseList.Length; i++)
            {
                _context.Enrollments.Add(new Enrollment { SID=studentId,CID=courseList[i]});
            }
            _context.SaveChanges();
            return true;
        }

        public bool RemoveStudentWithCourses(int studentId, int[] courseList)
        {
            for (int i = 0; i < courseList.Length; i++)
            {
                _context.Enrollments.Remove(new Enrollment { SID = studentId, CID = courseList[i] });
            }

            return _context.SaveChanges() > 0;
        }

        public List<Enrollment> FindEnrollmentsByStudentId(int studentId)
        {
            return _context.Enrollments.Where(x => x.SID == studentId).ToList();
        }

        public bool UpdateStudentWithCourses(int studentId, int[] courseList)
        {
            _context.Enrollments.RemoveRange(_context.Enrollments.Where(x => x.SID == studentId));
            for (int i = 0; i < courseList.Length; i++)
            {
                _context.Enrollments.Add(new Enrollment { SID = studentId, CID = courseList[i] });
            }

            return _context.SaveChanges() > 0;
        }
    }
}
