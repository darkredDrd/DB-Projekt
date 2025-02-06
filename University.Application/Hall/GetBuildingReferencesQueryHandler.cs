using MediatR;

using Microsoft.EntityFrameworkCores;

using Cinema.Persistence;

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