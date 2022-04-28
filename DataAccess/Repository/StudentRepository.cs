using Models;

namespace DataAccess.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public bool UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            return _context.SaveChanges() > 0;
        }
        public int AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            int id=student.Id;
            return id;
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student FindStudentById(int id)
        {
            return _context.Students.Find(id);
        }
    }
}
