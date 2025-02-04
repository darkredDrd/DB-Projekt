using MediatR;
using University.Models;

namespace Cinema.Application.Actor;

public class CreateStudentCommand : IRequest
{
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