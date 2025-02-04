using MediatR;

using Cinema.Models;

namespace Cinema.Application.Movies;

public class GetMovieQuery : IRequest<Movie>
{
    public int Id { get; set; }
}