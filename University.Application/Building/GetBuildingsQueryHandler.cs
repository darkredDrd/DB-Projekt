using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Models;
using Cinema.Persistence;

namespace Cinema.Application.Buildings;

public class GetBuildingsQueryHandler : IRequestHandler<GetBuildingsQuery, List<Building>>
{
    private readonly CinemaContext context;

    public GetBuildingsQueryHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task<List<Building>> Handle(GetBuildingsQuery request, CancellationToken cancellationToken)
    {
        var buildings = await context.Buildings //gleiche wie bei GetBuildingQueryHandler
            //.Include(course => course.Students)
            //.Include(course => course.Teachers)
            .ToListAsync(cancellationToken);
        return buildings;
    }
}