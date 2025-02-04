using MediatR;

using Cinema.Models;

namespace Cinema.Application.Screenings
{
    public class GetScreeningsQuery : IRequest<List<Screening>>
    {
    }
}
