using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IStudentRepository:IRepository<Student>
    {
        bool UpdateStudent(Student student);
        int AddStudent(Student student);

        List<Student> GetAllStudents();
        Student FindStudentById(int id);

    }
}
