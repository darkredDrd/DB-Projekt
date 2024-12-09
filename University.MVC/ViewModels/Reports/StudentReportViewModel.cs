using System.Composition;

using University.Models;

namespace University.MVC.ViewModels.Reports;

public class StudentReportViewModel
{
    public string FullName { get; set; }
    public DateTime? Birthday { get; set; }

    public List<CourseReportViewModel> Courses { get; set; }

    public static StudentReportViewModel FromStudent(Student student)
    {
        return new StudentReportViewModel
        {
            FullName = $"{student.FirstName} {student.LastName}",
            Birthday = student.Birthday,
            Courses = student.Courses.Select(course => CourseReportViewModel.FromCourse(student, course)).ToList()
        };
    }
}