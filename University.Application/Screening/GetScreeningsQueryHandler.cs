using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Models;
using Cinema.Persistence;

namespace Cinema.Application.Screenings;

public class GetScreeningsQueryHandler : IRequestHandler<GetScreeningsQuery, List<Screening>>
{
    private readonly CinemaContext context;

    public GetScreeningsQueryHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task<List<Revenue>> Handle(GetScreeningsQuery request, CancellationToken cancellationToken)
    {
        var screenings = await context.Screenings.ToListAsync(cancellationToken);
        return screenings;
    }
}