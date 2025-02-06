using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Models;
using Cinema.Persistence;

namespace Cinema.Application.Halls;

public class GetHallQueryQueryHandler : IRequestHandler<GetHallQuery, Hall>
{
    private readonly CinemaContext context;

    public GetHallQueryQueryHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task<Hall> Handle(GetHallQuery request, CancellationToken cancellationToken)
    {
        var hall = await context.Halls
            .Include(hall => hall.Building)
            .FirstOrDefaultAsync(hall => hall.Id == request.Id, cancellationToken);

        return hall;
    }
}