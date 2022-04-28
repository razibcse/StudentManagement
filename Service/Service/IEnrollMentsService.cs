using Models.ViewModels;

namespace Service.Service
{
    public interface IEnrollMentsService
    {
        bool AddStudentWithCourses(int studentId, int[] courseList);
        bool RemoveStudentWithCourses(int studentId, int[] courseList);
        List<EnrollmentsVM> FindEnrollmentsByStudentId(int studentId);
        bool UpdateStudentWithCourses(int studentId, int[] courseList);
    }
}
