using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IEnrollmentRepository
    {
        bool AddStudentWithCourses(int studentId,int[] courseList);
        bool RemoveStudentWithCourses(int studentId, int[] courseList);
        List<Enrollment> FindEnrollmentsByStudentId(int studentId);
        bool UpdateStudentWithCourses(int studentId, int[] courseList);

    }
}
