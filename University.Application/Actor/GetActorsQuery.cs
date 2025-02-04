using MediatR;
using Cinema.Models;

namespace Cinema.Application.Actors
{
    public class GetActorsQuery : IRequest<List<Actor>>
    {
    }
}
