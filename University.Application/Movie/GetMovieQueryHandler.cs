using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Models;
using Cinema.Persistence;

namespace Cinema.Application.Movies;

public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, Movie>
{
    private readonly CinemaContext context;

    public GetMovieQueryHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task<Movie> Handle(GetMovieQuery request, CancellationToken cancellationToken)
    {
        var movie = await context.Movies.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
        return movie;
    }
}