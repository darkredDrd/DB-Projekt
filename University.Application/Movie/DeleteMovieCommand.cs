using MediatR;

namespace Cinema.Application.Movies;

public class DeleteMovieCommand : IRequest
{
    public int Id { get; set; }
}