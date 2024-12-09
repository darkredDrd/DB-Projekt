using MediatR;

namespace University.Application.Students;

public class DeleteStudentCommand : IRequest
{
    public int Id { get; set; }
}