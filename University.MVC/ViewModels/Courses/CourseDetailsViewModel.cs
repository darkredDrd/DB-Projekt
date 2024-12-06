using University.Models;

namespace University.MVC.ViewModels.Courses;

public class CourseListViewModel
{
    public int Id { get; set; }

    public string Topic { get; set; }

    public int NumberOfHours { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public static CourseListViewModel FromCourse(Course course)
    {
        var courseListViewModel = new CourseListViewModel
        {
            Id = course.Id,
            Topic = course.Topic,
            NumberOfHours = course.NumberOfHours,
            StartDate = course.StartDate,
            EndDate = course.EndDate,
        };

        return courseListViewModel;
    }
}