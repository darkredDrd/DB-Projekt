namespace University.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Topic { get; set; }

        public int NumberOfHours { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
