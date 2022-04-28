using DataAccess.Repository;
using Models;
using Models.ViewModels;

namespace Service.Service
{
    public class CourseService:Service<Course>,ICourseService
    {
        ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository):base(courseRepository)
        {
            _courseRepository= courseRepository;
        }

        public void AddCourse(CourseVM courseVM)
        {
            Course course = new Course();
            course.Id = courseVM.Id;
            course.Name = courseVM.Name;

            _courseRepository.AddCourse(course);

        }

        public List<CourseVM> GetAllCourse()
        {
            List<Course> courses=_courseRepository.FindAll();

            List<CourseVM> result = new List<CourseVM>();
            foreach (Course course in courses)
            {
                CourseVM courseVM=new CourseVM { Id=course.Id, Name=course.Name};
                result.Add(courseVM);
            }
            return result;

        }


        public bool UpdateCourse(CourseVM courseVM)
        {
            Course course=new Course { Id=courseVM.Id, Name=courseVM.Name };
            
            return _courseRepository.update(course);

        }

        public bool RemoveCourse(CourseVM courseVM)
        {
            return _courseRepository.delete(new Course { Id=courseVM.Id,Name=courseVM.Name});

        }

        public CourseVM FindById(int id)
        {
            Course course=_courseRepository.FindById(id);
            return new CourseVM { Id=course.Id, Name=course.Name };

        }



    }
}
