using MediatR;

using University.Models;

namespace University.Application.Teachers;

public class UpdateTeacherCommand : IRequest
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public string PassportNumber { get; set; }

    public DateTime? Birthday { get; set; }

    public Movie ToTeacher()
    {
        var teacher = new Movie
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
}