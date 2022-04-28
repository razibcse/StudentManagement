using Models;

namespace DataAccess.Repository
{
    public interface ICourseRepository:IRepository<Course>
    {
        bool update(Course course);
        bool delete(Course course);
        bool AddCourse(Course course);
        Course FindById(int id);
        List<Course> FindAll();
    }
}
