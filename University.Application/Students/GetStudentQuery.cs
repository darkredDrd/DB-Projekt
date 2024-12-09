using MediatR;

using University.Models;

namespace University.Application.Students;

public class GetStudentQuery : IRequest<Student>
{
    public int Id { get; set; }
}