using System.ComponentModel.DataAnnotations;

using University.Application.Students;
using University.Models;

namespace University.MVC.ViewModels.Students;

public class StudentUpdateViewModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    [Display(Name = "First name")]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(100)]
    [Display(Name = "Last name")]
    public string LastName { get; set; }

    [MaxLength(15)]
    public string Phone { get; set; }

    [Required]
    [MaxLength(200)]
    public string Email { get; set; }

    [Required]
    [MaxLength(15)]
    [Display(Name = "Passport number")]
    public string PassportNumber { get; set; }

    public DateTime? Birthday { get; set; }

    public UpdateStudentCommand ToUpdateStudentCommand()
    {
        var updateStudentCommand = new UpdateStudentCommand
        {
            Id = this.Id,
            PassportNumber = this.PassportNumber,
            Email = this.Email,
            FirstName = this.FirstName,
            LastName = this.LastName,
            Phone = this.Phone,
            Birthday = this.Birthday
        };

        return updateStudentCommand;
    }

    public static StudentUpdateViewModel FromStudent(Revenue student)
    {
        var studentUpdateViewModel = new StudentUpdateViewModel
        {
            Id = student.Id,
            PassportNumber = student.PassportNumber,
            Email = student.Email,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Phone = student.Phone,
            Birthday = student.Birthday
        };

        return studentUpdateViewModel;
    }
}