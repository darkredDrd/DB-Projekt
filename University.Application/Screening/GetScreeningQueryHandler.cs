using System.Text.Json;
using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

using Cinema.Models;
using Cinema.Persistence;
using Cinema.Application.Screenings;

namespace Cinema.Application.Revenues;

public class GetScreeningQueryHandler : IRequestHandler<GetScreeningQuery, Screening>
{
    private readonly CinemaContext context;
    private readonly IDistributedCache cache;

    private TimeSpan threeMonths = new(0, 3, 0, 0, 0, 0);

    public GetScreeningQueryHandler(CinemaContext context, IDistributedCache cache)
    {
        this.context = context;
        this.cache = cache;
    }

    public async Task<Screening> Handle(GetScreeningQuery request, CancellationToken cancellationToken)
    {
        var screening = await GetScreeningFromCache(request);
        if (screening != null)
        {
            return screening;
        }

        screening = await GetScreeningFromDatabase(request, cancellationToken);
        await SetScreeningToCache(screening);

        return screening;
    }

    private async Task SetScreeningToCache(Screening screening)
    {
        var key = $"screening-{screening.Id}";

        var revenueAsSerializedJson = JsonSerializer.Serialize(screening);

        await cache.SetStringAsync(key, revenueAsSerializedJson, options: new DistributedCacheEntryOptions { SlidingExpiration = threeMonths });
    }

    private async Task<Screening> GetScreeningFromCache(GetScreeningQuery request)
    {
        var key = $"screening-{request.Id}";

        var screeningAsSerializedJson = await cache.GetStringAsync(key);
        if (screeningAsSerializedJson == null)
        {
            return null;
        }

        var screening = JsonSerializer.Deserialize<Screening>(screeningAsSerializedJson);
        return screening;
    }

    private async Task<Screening> GetScreeningFromDatabase(GetScreeningQuery request, CancellationToken cancellationToken)
    {
        var screening = await context.Screenings.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);
        return screening;
    }
}