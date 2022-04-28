using DataAccess.Repository;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class EnrollMentsService:IEnrollMentsService
    {
        private IEnrollmentRepository _enrollmentRepository;
        public EnrollMentsService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository=enrollmentRepository;
        }

        public bool AddStudentWithCourses(int studentId, int[] courseList)
        {
            
            return _enrollmentRepository.AddStudentWithCourses(studentId, courseList);
        }

        public bool RemoveStudentWithCourses(int studentId, int[] courseList)
        {
            return _enrollmentRepository.RemoveStudentWithCourses(studentId,courseList);
        }
        public List<EnrollmentsVM> FindEnrollmentsByStudentId(int studentId)
        {
            List<EnrollmentsVM> enrollmentsVMs = new List<EnrollmentsVM>();
            foreach (var item in _enrollmentRepository.FindEnrollmentsByStudentId(studentId))
            {
                enrollmentsVMs.Add(new EnrollmentsVM { Sid = item.SID, Cid = item.CID });
            }
            return enrollmentsVMs;
        }

        public bool UpdateStudentWithCourses(int studentId, int[] courseList)
        {

            return _enrollmentRepository.UpdateStudentWithCourses(studentId, courseList);
        }
    }
}
