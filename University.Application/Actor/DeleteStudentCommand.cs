using MediatR;

namespace Cinema.Application.Actor;

public class DeleteStudentCommand : IRequest
{
    public int Id { get; set; }
}