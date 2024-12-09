using MediatR;

using University.Models;

namespace University.Application.Teachers;

public class CreateTeacherCommand : IRequest
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public string PassportNumber { get; set; }

    public DateTime? Birthday { get; set; }

    public Teacher ToTeacher()
    {
        var teacher = new Teacher
        {
            PassportNumber = this.PassportNumber,
            Email = this.Email,
            FirstName = this.FirstName,
            LastName = this.LastName,
            Phone = this.Phone,
            Birthday = this.Birthday
        };

        return teacher;
    }
}