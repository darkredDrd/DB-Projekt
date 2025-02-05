using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Persistence;

namespace Cinema.Application.Hall;

public class GetHallReferencesQueryHandler : IRequestHandler<GetHallReferencesQuery, HallReferences>
{
    private readonly CinemaContext context;

    public GetHallReferencesQueryHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task<HallReferences> Handle(GetHallReferencesQuery request, CancellationToken cancellationToken)
    {
        var allBuildings = await context.Buildings.ToListAsync(cancellationToken);

        return new RevenueReferences
        {
            Buildings = allBuildings
        };
    }
}