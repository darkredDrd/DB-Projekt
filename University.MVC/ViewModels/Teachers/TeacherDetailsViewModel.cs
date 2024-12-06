using System.ComponentModel.DataAnnotations;

using University.Models;

namespace University.MVC.ViewModels.Teachers;

public class TeacherDetailsViewModel
{
    public int Id { get; set; }

    [Display(Name = "First name")]
    public string FirstName { get; set; }

    [Display(Name = "Last name")]
    public string LastName { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    [Display(Name = "Passport number")]
    public string PassportNumber { get; set; }

    public DateTime? Birthday { get; set; }

    public static TeacherDetailsViewModel FromTeacher(Teacher teacher)
    {
        var teacherDetailsViewModel = new TeacherDetailsViewModel()
        {
            Id = teacher.Id,
            PassportNumber = teacher.PassportNumber,
            Email = teacher.Email,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            Phone = teacher.Phone,
            Birthday = teacher.Birthday
        };

        return teacherDetailsViewModel;
    }
}