using MediatR;

using Cinema.Models;

namespace Cinema.Application.Movies
{
    public class GetMoviesQuery : IRequest<List<Movie>>
    {
    }
}