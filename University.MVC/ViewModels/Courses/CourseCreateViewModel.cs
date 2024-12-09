using System.ComponentModel.DataAnnotations;

using University.Application.Courses;
using University.Models;

namespace University.MVC.ViewModels.Courses;

public class CourseCreateViewModel
{
    public string Topic { get; set; }

    [Display(Name = "Number of hours")]
    public int NumberOfHours { get; set; }

    [Display(Name = "Start date")]
    public DateTime StartDate { get; set; }

    [Display(Name = "End date")]
    public DateTime EndDate { get; set; }

    public CreateCourseCommand ToCreateCourseCommand()
    {
        var createCourseCommand = new CreateCourseCommand
        {
            Topic = this.Topic,
            NumberOfHours = this.NumberOfHours,
            StartDate = this.StartDate,
            EndDate = this.EndDate,
        };

        return createCourseCommand;
    }
}