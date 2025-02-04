using MediatR;

using University.Models;

namespace University.Application.Students;

public class GetStudentQuery : IRequest<Revenue>
{
    public int Id { get; set; }
}