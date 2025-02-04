using MediatR;

namespace Cinema.Application.Actors;

public class DeleteActorCommand : IRequest
{
    public int Id { get; set; }
}