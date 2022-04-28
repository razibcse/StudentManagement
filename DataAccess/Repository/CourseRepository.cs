using Models;
namespace DataAccess.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public bool AddCourse(Course course)
        {
            _context.Courses.Add(course);
            return _context.SaveChanges() > 0;
        }

        public bool delete(Course course)
        {
            _context.Courses.Remove(course);
            return _context.SaveChanges() > 0;
        }

        public Course FindById(int id)
        {
            Course course = _context.Courses.Find(id);
            return course;
        }

        public List<Course> FindAll()
        {
            List<Course> courses = _context.Courses.ToList();
            return courses;
        }

        public bool update(Course course)
        {
            _context.Courses.Update(course);
            return _context.SaveChanges()>0;
        }


    }
}
