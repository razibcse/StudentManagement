using DataAccess.Repository;
using Models;
using Models.ViewModels;

namespace Service.Service
{
    public class StudentService:Service<Student>,IStudentService
    {
        IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository) : base(studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public int AddStudent(StudentVM student)
        {

            return _studentRepository.AddStudent(new Student {Name=student.Name,DateOfBirth=student.DateOfBirth.Date,RollNo=student.RollNo,Email=student.Email,Courses=student.Courses});
        }

        public List<StudentVM> GetAllStudents()
        {
            List<StudentVM> students = new List<StudentVM>();
            foreach (Student student in _studentRepository.GetAllStudents())
            {
                students.Add(new StudentVM {Id=student.Id, Name=student.Name,Email=student.Email,RollNo=student.RollNo,Courses=student.Courses,DateOfBirth=student.DateOfBirth.Date});
            }

            return students;
        }

        public StudentVM FindStudentById(int id)
        {
            Student student=_studentRepository.FindStudentById(id);
            return new StudentVM { Id = student.Id, Name = student.Name, Email = student.Email, RollNo = student.RollNo, Courses = student.Courses, DateOfBirth = student.DateOfBirth.Date };
        }

        public bool UpdateStudent(StudentVM student)
        {
            return _studentRepository.UpdateStudent(new Student {Id=student.Id, Courses = student.Courses, DateOfBirth = student.DateOfBirth.Date,RollNo=student.RollNo,Email=student.Email,Name=student.Name});
        }
    }
}
