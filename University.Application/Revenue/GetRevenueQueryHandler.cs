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
    private readonly IDistributedCache cache;

    private TimeSpan threeMonths = new(0, 3, 0, 0, 0, 0);

    public GetRevenueQueryHandler(CinemaContext context, IDistributedCache cache)
    {
        this.context = context;
        this.cache = cache;
    }

    public async Task<Revenue> Handle(GetRevenueQuery request, CancellationToken cancellationToken)
    {
        var revenue = await GetRevenueFromCache(request);
        if (revenue != null)
        {
            return revenue;
        }

        revenue = await GetRevenueFromDatabase(request, cancellationToken);
        await SetRevenueToCache(revenue);

        return revenue;
    }

    private async Task SetRevenueToCache(Revenue revenue)
    {
        var key = $"revenue-{revenue.Id}";

        var revenueAsSerializedJson = JsonSerializer.Serialize(revenue);

        await cache.SetStringAsync(key, revenueAsSerializedJson, options: new DistributedCacheEntryOptions { SlidingExpiration = threeMonths });
    }

    private async Task<Revenue> GetRevenueFromCache(GetRevenueQuery request)
    {
        var key = $"revenue-{request.Id}";

        var revenueAsSerializedJson = await cache.GetStringAsync(key);
        if (revenueAsSerializedJson == null)
        {
            return null;
        }

        var revenue = JsonSerializer.Deserialize<Revenue>(revenueAsSerializedJson);
        return revenue;
    }

    private async Task<Revenue> GetRevenueFromDatabase(GetRevenueQuery request, CancellationToken cancellationToken)
    {
        var revenue = await context.Revenues.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);
        return revenue;
    }
}