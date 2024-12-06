namespace University.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string PassportNumber { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<Course> Courses { get; set; }

        public ICollection<Mark> Marks { get; set; }
    }
}
