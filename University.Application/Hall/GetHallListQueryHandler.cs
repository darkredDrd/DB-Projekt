using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Models;
using Cinema.Persistence;

namespace Cinema.Application.Halls;

public class GetHallListQueryHandler : IRequestHandler<GetHallListQuery, List<Hall>>
{
    private readonly CinemaContext context;

    public GetHallListQueryHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task<List<Hall>> Handle(GetHallListQuery request, CancellationToken cancellationToken)
    {
        var halls = await context.Halls
            .Include(hall => hall.Building)
            .ToListAsync(cancellationToken);

        return halls;
    }
}