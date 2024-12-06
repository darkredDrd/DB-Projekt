using System.ComponentModel.DataAnnotations;
using System.Linq;
using University.Models;

namespace University.MVC.Models.Courses;

public class CourseUpdateViewModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Topic { get; set; }

    public int NumberOfHours { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public List<StudentCheckbox> StudentCheckboxes { get; set; } = new();

    public Course ToCourse()
    {
        var course = new Course
        {
            Id = this.Id,
            Topic = this.Topic,
            NumberOfHours = this.NumberOfHours,
            StartDate = this.StartDate,
            EndDate = this.EndDate,
        };

        return course;
    }

    public static CourseUpdateViewModel FromCourse(Course course, List<Student> allStudents)
    {
        var courseUpdateViewModel = new CourseUpdateViewModel
        {
            Id = course.Id,
            Topic = course.Topic,
            NumberOfHours = course.NumberOfHours,
            StartDate = course.StartDate,
            EndDate = course.EndDate,
        };

        foreach (var student in allStudents)
        {
            var studentCheckbox = new StudentCheckbox
            {
                Id = student.Id,
                Label = $"{student.FirstName} {student.LastName}",
                Checked = course.Students.Any(cs => cs.Id == student.Id)
            };

            courseUpdateViewModel.StudentCheckboxes.Add(studentCheckbox);
        }

        return courseUpdateViewModel;
    }
}

public class StudentCheckbox
{
    public int Id { get; set; }
    public string Label { get; set; }

    public bool Checked { get; set; }
}