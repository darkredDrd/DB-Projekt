using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Persistence;

namespace Cinema.Application.Revenues;

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

        return new ScreeningReferences
        {
            Movies = allMovies,
        };
    }
}