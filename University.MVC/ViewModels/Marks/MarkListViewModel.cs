using System.ComponentModel.DataAnnotations;

using University.Models;

namespace University.MVC.ViewModels.Marks;

public class MarkListViewModel
{
    public int Id { get; set; }
    public int Score { get; set; }

    [Display(Name = "Date awarded")]
    public DateTime DateAwarded { get; set; }

    [Display(Name = "Course topic")]
    public string CourseTopic { get; set; }
    public string TeacherFullName { get; set; }
    public string StudentFullName { get; set; }

    public static MarkListViewModel FromMark(Mark mark)
    {
        var markListViewModel = new MarkListViewModel
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