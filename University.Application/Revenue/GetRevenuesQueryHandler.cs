using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Models;
using Cinema.Persistence;

namespace Cinema.Application.Revenues;

public class GetRevenuesQueryHandler : IRequestHandler<GetRevenuesQuery, List<Revenue>>
{
    private readonly CinemaContext context;

    public GetRevenuesQueryHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task<List<Revenue>> Handle(GetRevenuesQuery request, CancellationToken cancellationToken)
    {
        var revenues = await context.Revenues.ToListAsync(cancellationToken);
        return revenues;
    }
}