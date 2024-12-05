using University.Models;

namespace University.MVC.Models.Students;

public class StudentDetailsViewModel
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

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