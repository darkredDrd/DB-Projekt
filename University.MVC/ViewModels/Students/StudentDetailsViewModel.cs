using System.ComponentModel.DataAnnotations;

using University.Models;

namespace University.MVC.ViewModels.Students;

public class StudentDetailsViewModel
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

    public static StudentDetailsViewModel FromStudent(Student student)
    {
        var studentDetailsViewModel = new StudentDetailsViewModel()
        {
            Id = student.Id,
            PassportNumber = student.PassportNumber,
            Email = student.Email,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Phone = student.Phone,
            Birthday = student.Birthday
        };

        return studentDetailsViewModel;
    }
}