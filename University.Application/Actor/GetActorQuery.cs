using MediatR;
using Cinema.Models;

namespace Cinema.Application.Actors;

public class GetActorQuery : IRequest<Actor>
{
    public int Id { get; set; }
}