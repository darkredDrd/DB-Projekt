using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Persistence;

namespace Cinema.Application.Screenings;

public class GetScreeningReferencesQueryHandler : IRequestHandler<GetScreeningReferencesQuery, ScreeningReferences>
{
    private readonly CinemaContext context;

    public GetScreeningReferencesQueryHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task<ScreeningReferences> Handle(GetScreeningReferencesQuery request, CancellationToken cancellationToken)
    {
        var allMovies = await context.Movies.ToListAsync(cancellationToken);

        var allHalls = await context.Halls.ToListAsync(cancellationToken);

        return new ScreeningReferences
        {
            Movies = allMovies,
            Halls = allHalls
        };
    }
}