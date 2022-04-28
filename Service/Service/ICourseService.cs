using Models;
using Models.ViewModels;

namespace Service.Service
{
    public interface ICourseService:IService<Course>
    {
       void AddCourse(CourseVM course);
        List<CourseVM> GetAllCourse();
        bool UpdateCourse(CourseVM courseVM);
        bool RemoveCourse(CourseVM courseVM);
        CourseVM FindById(int id);

    }
}
