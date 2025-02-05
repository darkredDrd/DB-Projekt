using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Persistence;

namespace Cinema.Application.Hall;

public class GetRevenueReferencesQueryHandler : IRequestHandler<GetHallReferencesQuery, RevenueReferences>
{
    private readonly CinemaContext context;

    public GetHallReferencesQueryHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task<RevenueReferences> Handle(GetHallReferencesQuery request, CancellationToken cancellationToken)
    {
        var allCinemas = await context.Cinemas.ToListAsync(cancellationToken);

        return new RevenueReferences
        {
            Cinemas = allCinemas
        };
    }
}