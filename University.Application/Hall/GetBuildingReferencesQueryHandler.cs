using MediatR;


using Cinema.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Application.Halls;

public class GetBuildingReferencesQueryHandler : IRequestHandler<GetBuildingReferencesQuery, BuildingReferences>
{
    private readonly CinemaContext context;

    public GetBuildingReferencesQueryHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task<BuildingReferences> Handle(GetBuildingReferencesQuery request, CancellationToken cancellationToken)
    {
        var allBuildings = await context.Buildings.ToListAsync(cancellationToken);

        return new BuildingReferences
        {
            Buildings = allBuildings
        };
    }
}