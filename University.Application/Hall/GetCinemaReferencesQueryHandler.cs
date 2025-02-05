using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Persistence;

namespace Cinema.Application.Hall;

public class GetScreeningReferencesQueryHandler : IRequestHandler<GetScreeningReferencesQuery, CinemaReferences>
{
    private readonly CinemaContext context;

    public GetCinemaReferencesQueryHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task<CinemaReferences> Handle(GetScreeningReferencesQuery request, CancellationToken cancellationToken)
    {
        var allCinemas = await context.Cinemas.ToListAsync(cancellationToken);

        return new CinemaReferences
        {
            Cinemas = allCinemas
        };
    }
}