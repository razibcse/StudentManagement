using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public interface IStudentService
    {

        StudentVM FindStudentById(int id);
        int AddStudent(StudentVM student);
        List<StudentVM> GetAllStudents();
        bool UpdateStudent(StudentVM student);
    }
}
