using System.ComponentModel.DataAnnotations;

using University.Models;

namespace University.MVC.Models.Students;

public class StudentUpdateViewModel
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

    public Student ToStudent()
    {
        var student = new Student
        {
            PassportNumber = this.PassportNumber,
            Email = this.Email,
            FirstName = this.FirstName,
            LastName = this.LastName,
            Phone = this.Phone,
            Birthday = this.Birthday
        };

        return student;
    }

    public static StudentUpdateViewModel FromStudent(Student student)
    {
        var studentUpdateViewModel = new StudentUpdateViewModel
        {
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