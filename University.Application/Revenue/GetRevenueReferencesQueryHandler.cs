using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Persistence;

namespace Cinema.Application.Revenues;

public class GetRevenueReferencesQueryHandler : IRequestHandler<GetRevenueReferencesQuery, RevenueReferences>
{
    private readonly CinemaContext context;

    public GetRevenueReferencesQueryHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task<RevenueReferences> Handle(GetRevenueReferencesQuery request, CancellationToken cancellationToken)
    {
        var allScreenings = await context.Screenings.ToListAsync(cancellationToken);

        return new RevenueReferences
        {
            Screenings = allScreenings,
        };
    }
}