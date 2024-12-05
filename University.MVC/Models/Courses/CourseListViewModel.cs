using System.ComponentModel.DataAnnotations;

using University.Models;

namespace University.MVC.Models.Courses;

public class CourseDetailsViewModel
{
    public int Id { get; set; }

    public string Topic { get; set; }

    public int NumberOfHours { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public static CourseDetailsViewModel FromCourse(Course course)
    {
        var courseDetailsViewModel = new CourseDetailsViewModel
        {
            Id = course.Id,
            Topic = course.Topic,
            NumberOfHours = course.NumberOfHours,
            StartDate = course.StartDate,
            EndDate = course.EndDate,
        };

        return courseDetailsViewModel;
    }
}