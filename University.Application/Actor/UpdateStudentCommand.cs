using MediatR;
using University.Models;

namespace Cinema.Application.Actor;

public class UpdateStudentCommand : IRequest
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public string PassportNumber { get; set; }

    public DateTime? Birthday { get; set; }

    public Revenue ToStudent()
    {
        var student = new Revenue
        {
            Id = Id,
            PassportNumber = PassportNumber,
            Email = Email,
            FirstName = FirstName,
            LastName = LastName,
            Phone = Phone,
            Birthday = Birthday
        };

        return student;
    }
}