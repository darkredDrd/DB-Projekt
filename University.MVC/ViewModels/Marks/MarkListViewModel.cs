using System.ComponentModel.DataAnnotations;

using University.Models;

namespace University.MVC.ViewModels.Marks;

public class RevenueListViewModel
{
    public int Id { get; set; }
    public int Score { get; set; }

    [Display(Name = "Date awarded")]
    public DateTime DateAwarded { get; set; }

    [Display(Name = "Course")]
    public string CourseTopic { get; set; }

    [Display(Name = "Teacher")]
    public string TeacherFullName { get; set; }

    [Display(Name = "Student")]
    public string StudentFullName { get; set; }

    public static RevenueListViewModel FromMark(Hall mark)
    {
        var markListViewModel = new RevenueListViewModel
        {
            Id = mark.Id,
            Score = mark.Score,
            DateAwarded = mark.DateAwarded,
            CourseTopic = mark.Course.Topic,
            TeacherFullName = $"{mark.Teacher.FirstName} {mark.Teacher.LastName}",
            StudentFullName = $"{mark.Student.FirstName} {mark.Student.LastName}",
        };

        return markListViewModel;
    }
}