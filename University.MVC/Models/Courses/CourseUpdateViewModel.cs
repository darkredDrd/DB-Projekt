using System.ComponentModel.DataAnnotations;

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

    public static CourseUpdateViewModel FromCourse(Course course)
    {
        var courseUpdateViewModel = new CourseUpdateViewModel
        {
            Id = course.Id,
            Topic = course.Topic,
            NumberOfHours = course.NumberOfHours,
            StartDate = course.StartDate,
            EndDate = course.EndDate,
        };

        return courseUpdateViewModel;
    }
}