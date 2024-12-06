using System.ComponentModel.DataAnnotations;

using University.Models;

namespace University.MVC.ViewModels.Teachers;

public class TeacherUpdateViewModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }

    [MaxLength(15)]
    public string Phone { get; set; }

    [Required]
    [MaxLength(200)]
    public string Email { get; set; }

    [Required]
    [MaxLength(15)]
    public string PassportNumber { get; set; }

    public DateTime? Birthday { get; set; }

    public Teacher ToTeacher()
    {
        var teacher = new Teacher
        {
            Id = this.Id,
            PassportNumber = this.PassportNumber,
            Email = this.Email,
            FirstName = this.FirstName,
            LastName = this.LastName,
            Phone = this.Phone,
            Birthday = this.Birthday
        };

        return teacher;
    }

    public static TeacherUpdateViewModel FromTeacher(Teacher teacher)
    {
        var teacherUpdateViewModel = new TeacherUpdateViewModel
        {
            Id = teacher.Id,
            PassportNumber = teacher.PassportNumber,
            Email = teacher.Email,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            Phone = teacher.Phone,
            Birthday = teacher.Birthday
        };

        return teacherUpdateViewModel;
    }
}