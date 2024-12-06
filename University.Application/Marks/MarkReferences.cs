using University.Models;

namespace University.Application.Marks
{
    public class MarkReferences
    {
        public List<Course> Courses { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }
    }
}
