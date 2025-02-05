using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Persistence;

namespace Cinema.Application.Marks;

public class GetRevenueReferencesQueryHandler : IRequestHandler<GetMarkReferencesQuery, RevenueReferences>
{
    private readonly CinemaContext context;

    public GetMarkReferencesQueryHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task<RevenueReferences> Handle(GetMarkReferencesQuery request, CancellationToken cancellationToken)
    {
        var allCinemas = await context.Cinemas.ToListAsync(cancellationToken);

        return new RevenueReferences
        {
            Cinemas = allCinemas
        };
    }
}