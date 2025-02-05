using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Models;
using Cinema.Persistence;

namespace Cinema.Application.Marks;

public class GetMarkQueryQueryHandler : IRequestHandler<GetMarkQuery, Hall>
{
    private readonly CinemaContext context;

    public GetMarkQueryQueryHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task<Hall> Handle(GetMarkQuery request, CancellationToken cancellationToken)
    {
        var hall = await context.Halls
            .Include(hall => hall.Cinema)
            .FirstOrDefaultAsync(hall => hall.Id == request.Id, cancellationToken);

        return hall;
    }
}