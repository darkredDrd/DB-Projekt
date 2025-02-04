using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Models;
using Cinema.Persistence;

namespace Cinema.Application.Movies;

public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, List<Movie>>
{
    private readonly CinemaContext context;

    public GetMoviesQueryHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task<List<Movie>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        var movies = await context.Movies.ToListAsync(cancellationToken);
        return movies;
    }
}