namespace Models.ViewModels
{
    public class StudentVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string RollNo { get; set; }
        public string Email { get; set; }
        public string Courses { get; set; } = "";
        public List<CourseVM> CourseList { get; set; } = new List<CourseVM>();

    }
}
