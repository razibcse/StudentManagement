using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using Service.Service;

namespace StudentManagement.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly IEnrollMentsService _enrollMentsService;
        public StudentsController(IStudentService studentService, ICourseService courseService, IEnrollMentsService enrollMentsService)
        {
            _studentService = studentService;
            _courseService = courseService;
            _enrollMentsService = enrollMentsService;
        }

        public IActionResult Index()
        {
            return View(_studentService.GetAllStudents());
        }

        private StudentVM GenerateStudentEditData(StudentVM student, List<CourseVM> courses, List<EnrollmentsVM> enrollments)
        {
            Dictionary<int, CourseVM> mapCourses = new Dictionary<int, CourseVM>();
            foreach (var item in courses)
            {
                mapCourses[item.Id] = item;
            }

            Dictionary<int, EnrollmentsVM> mapEnrollments = new Dictionary<int, EnrollmentsVM>();
            foreach (var item in enrollments)
            {
                mapEnrollments[item.Cid] = item;
            }

            foreach (var item in courses)
            {
                if (mapEnrollments.ContainsKey(item.Id))
                {
                    item.IsTaken = true;
                }
                student.CourseList.Add(item);
            }

            return student;
        }

        public IActionResult Create()
        {
            var student = new StudentVM();
            student.CourseList = _courseService.GetAllCourse();

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentVM student, int[] courseList)
        {
            if (ModelState.IsValid)
            {
                string courses = "";
                if (courseList.Count() > 0)
                {
                    courses = _courseService.FindById(courseList[0]).Name;
                }
                for (int i = 1; i < courseList.Length; i++)
                {
                    courses += ", " + _courseService.FindById(courseList[i]).Name;
                }
                student.Courses = courses;

                int id = _studentService.AddStudent(student);
                if (courseList.Length > 0)
                {
                    _enrollMentsService.AddStudentWithCourses(id, courseList);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public IActionResult Edit(int id)
        {
            StudentVM student = _studentService.FindStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            List<CourseVM> courses = _courseService.GetAllCourse();
            List<EnrollmentsVM> enrollments = _enrollMentsService.FindEnrollmentsByStudentId(student.Id);

            return View(GenerateStudentEditData(student, courses, enrollments));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentVM student, int[] courseList)
        {
            if (ModelState.IsValid)
            {
                _enrollMentsService.UpdateStudentWithCourses(student.Id, courseList);
                string courses = "";
                if (courseList.Count() > 0)
                {
                    courses = _courseService.FindById(courseList[0]).Name;
                }
                for (int i = 1; i < courseList.Length; i++)
                {
                    courses += ", " + _courseService.FindById(courseList[i]).Name;
                }
                student.Courses = courses;
                _studentService.UpdateStudent(student);

                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }







    

        public IActionResult Index2()
        {
            return View(_studentService.GetAllStudents());
        }

        public IActionResult Create2()
        {
            var studentVM = new StudentVM();
            studentVM.CourseList = _courseService.GetAllCourse();

            List<CourseVM> NewFormatedcourses = new List<CourseVM>();
            for (int i = 0; i < studentVM.CourseList.Count(); i += 4)
            {
                string namelist = studentVM.CourseList[i].Name;
                for (int j = i + 1; j < i + 4; j++)
                {
                    if (j == studentVM.CourseList.Count)
                    {
                        break;
                    }
                    else
                    {
                        namelist += ",  " + studentVM.CourseList[j].Name;
                    }

                }
                studentVM.CourseList[i].Name = namelist;
                NewFormatedcourses.Add(studentVM.CourseList[i]);

            }
            studentVM.CourseList = NewFormatedcourses;

            return View(studentVM);
        }

        [HttpPost]
        public IActionResult Create2(StudentVM student, int[] courseList)
        {
            if (ModelState.IsValid)
            {
                List<CourseVM> clist = _courseService.GetAllCourse();
                List<int> list = new List<int>();
                if (courseList.Length > 0)
                {
                    for (int i = 0; i < courseList.Length; i++)
                    {
                        int idx = courseList[i] * 4 - 4;
                        for (int j = idx; j < idx + 4; j++)
                        {
                            if (j == clist.Count())
                            {
                                break;
                            }
                            list.Add(clist[j].Id);
                        }
                    }
                }

                string courses = "";
                if (list.Count() > 0)
                {
                    courses = _courseService.FindById(list[0]).Name;
                }
                for (int i = 1; i < list.Count(); i++)
                {
                    courses += ", " + _courseService.FindById(list[i]).Name;
                }
                student.Courses = courses;

                int id = _studentService.AddStudent(student);

                if (courseList.Length > 0)
                {
                    _enrollMentsService.AddStudentWithCourses(id, list.ToArray());
                }

                return RedirectToAction(nameof(Index2));
            }

            return View(student);

        }

        private StudentVM GeneratedEdit2Data(StudentVM student, List<CourseVM> courses, List<EnrollmentsVM> enrollments)
        {
            Dictionary<int, CourseVM> mapCourses = new Dictionary<int, CourseVM>();
            foreach (var item in courses)
            {
                mapCourses[item.Id] = item;
            }

            Dictionary<int, EnrollmentsVM> mapEnrollments = new Dictionary<int, EnrollmentsVM>();
            foreach (var item in enrollments)
            {
                mapEnrollments[item.Cid] = item;
            }

            List<CourseVM> NewFormatedcourses = new List<CourseVM>();
            int total = 0;
            for (int i = 0; i < courses.Count(); i += 4)
            {
                string namelist = student.CourseList[i].Name;
                int cnt=1;
                ++total;
                
                for (int j = i + 1; j < i + 4; j++)
                {
                    if (j == student.CourseList.Count)
                    {
                        break;
                    }
                    else
                    {
                        if (mapEnrollments.ContainsKey(courses[j].Id))
                        {
                            ++cnt;
                            //item.IsTaken = true;
                        }
                        namelist += ",  " + student.CourseList[j].Name;
                    }

                }
                if(cnt == 4)
                {
                    student.CourseList[i].IsTaken = true;
                }
                student.CourseList[i].Name = namelist;

                NewFormatedcourses.Add(student.CourseList[i]);

            }
            student.CourseList = NewFormatedcourses;


            return student;
        }

        public IActionResult Edit2(int id)
        {
            StudentVM studentVM = _studentService.FindStudentById(id);
            if (studentVM == null)
            {
                return NotFound();
            }
            List<CourseVM> courses = _courseService.GetAllCourse();
            List<EnrollmentsVM> enrollments = _enrollMentsService.FindEnrollmentsByStudentId(studentVM.Id);
            studentVM.CourseList = courses;

            return View(GeneratedEdit2Data(studentVM, courses, enrollments));
        }


        [HttpPost]
        public IActionResult Edit2(StudentVM student, int[] courseList)
        {
            if (ModelState.IsValid)
            {
                List<CourseVM> clist = _courseService.GetAllCourse();
                List<int> list = new List<int>();
                if (courseList.Length > 0)
                {
                    for (int i = 0; i < courseList.Length; i++)
                    {
                        int idx = courseList[i] * 4 - 4;
                        for (int j = idx; j < idx + 4; j++)
                        {
                            if (j == clist.Count())
                            {
                                break;
                            }
                            list.Add(clist[j].Id);
                        }
                    }
                }

                string courses = "";
                if (list.Count() > 0)
                {
                    courses = _courseService.FindById(list[0]).Name;
                }
                for (int i = 1; i < list.Count(); i++)
                {
                    courses += ", " + _courseService.FindById(list[i]).Name;
                }
                student.Courses = courses;

                _studentService.UpdateStudent(student);

                if (courseList.Length > 0)
                {
                    _enrollMentsService.UpdateStudentWithCourses(student.Id, list.ToArray());
                }

                return RedirectToAction(nameof(Index2));
            }

            return View(student);

        }

    }
}
