namespace University.Models.Reports;

public class MongoDbStudent
{
    public string FullName { get; set; }
    public DateTime? Birthday { get; set; }

    public List<MongoDbCourse> Courses { get; set; }

    public static MongoDbStudent FromStudent(Student student)
    {
        return new MongoDbStudent
        {
            FullName = $"{student.FirstName} {student.LastName}",
            Birthday = student.Birthday,
            Courses = student.Courses.Select(course => MongoDbCourse.FromCourse(student, course)).ToList()
        };
    }
}