using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Persistence;

namespace Cinema.Application.Hall;

public class GetBuildingReferencesQueryHandler : IRequestHandler<GetBuildingReferencesQuery, BuildingReferences>
{
    private readonly CinemaContext context;

    public GetBuildingReferencesQueryHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task<BuildingReferences> Handle(GetBuildingReferencesQuery request, CancellationToken cancellationToken)
    {
        var allBuilding = await context.Buildings.ToListAsync(cancellationToken); //Vielleicht Fehler mit Buildings

        return new BuildingReferences
        {
            Building = allBuilding
        };
    }
}