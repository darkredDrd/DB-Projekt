using MediatR;

namespace Cinema.Application.Marks;

public class DeleteMarkCommand : IRequest
{
    public int Id { get; set; }
}