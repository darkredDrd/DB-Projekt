using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Models;
using Cinema.Persistence;

namespace Cinema.Application.Marks;

public class GetMarksListQueryHandler : IRequestHandler<GetMarksListQuery, List<Hall>>
{
    private readonly CinemaContext context;

    public GetMarksListQueryHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task<List<Hall>> Handle(GetMarksListQuery request, CancellationToken cancellationToken)
    {
        var halls = await context.Halls
            .Include(hall => hall.Cinema)
            .ToListAsync(cancellationToken);

        return halls;
    }
}