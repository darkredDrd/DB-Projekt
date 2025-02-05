using System.Text.Json;
using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

using Cinema.Models;
using Cinema.Persistence;

namespace Cinema.Application.Revenues;

public class GetRevenueQueryHandler : IRequestHandler<GetRevenueQuery, Revenue>
{
    private readonly CinemaContext context;

    public GetRevenueQueryHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task<Revenue> Handle(GetRevenueQuery request, CancellationToken cancellationToken)
    {
        var revenue = await context.Revenues
           .Include(revenue => revenue.Screening)
           .FirstOrDefaultAsync(revenue => revenue.Id == request.Id, cancellationToken);
        
        return revenue;
    }
}