using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Models;
using Cinema.Persistence;

namespace Cinema.Application.Buildings;

public class GetBuildingQueryHandler : IRequestHandler<GetBuildingQuery, Building>
{
    private readonly CinemaContext context;

    public GetBuildingQueryHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task<Building> Handle(GetBuildingQuery request, CancellationToken cancellationToken)
    {
        var building = await context.Buildings      //wichtig für many to many aber für hier unwichtig (1-many)
            //.Include(course => course.Students)
            //.Include(course => course.Teachers)
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);   //das hier in b umbennen?
        return building;
    }
}