using Cinema.Models;
using MediatR;

using Microsoft.EntityFrameworkCore;
using Cinema.Models;
using Cinema.Persistence;

namespace Cinema.Application.Actors;

public class GetActorsQueryHandler : IRequestHandler<GetActorsQuery, List<Actor>>
{
    private readonly CinemaContext context;

    public GetActorsQueryHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task<List<Actor>> Handle(GetActorsQuery request, CancellationToken cancellationToken)
    {
        var actor = await context.Actors.ToListAsync(cancellationToken);
        return actor;
    }
}