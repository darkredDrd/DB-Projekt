using System.Text.Json;
using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Cinema.Models;
using Cinema.Persistence;

namespace Cinema.Application.Actors;

public class GetActorQueryHandler : IRequestHandler<GetActorQuery, Actor>
{
    private readonly CinemaContext context;
    private readonly IDistributedCache cache;

    private TimeSpan threeMonths = new(0, 3, 0, 0, 0, 0);// verstehen was das macht

    public GetActorQueryHandler(CinemaContext context, IDistributedCache cache)
    {
        this.context = context;
        this.cache = cache;
    }

    public async Task<Actor> Handle(GetActorQuery request, CancellationToken cancellationToken)
    {
        var actor = await GetActorFromCache(request);
        if (actor != null)
        {
            return actor;
        }

        actor = await GetActorFromDatabase(request, cancellationToken);
        await SetActorToCache(actor);

        return actor;
    }

    private async Task SetActorToCache(Actor actor)
    {
        var key = $"actor-{actor.Id}";

        var actorAsSerializedJson = JsonSerializer.Serialize(actor);

        await cache.SetStringAsync(key, actorAsSerializedJson, options: new DistributedCacheEntryOptions { SlidingExpiration = threeMonths });
    }

    private async Task<Actor> GetActorFromCache(GetActorQuery request)
    {
        var key = $"actor-{request.Id}";

        var actorAsSerializedJson = await cache.GetStringAsync(key);
        if (actorAsSerializedJson == null)
        {
            return null;
        }

        var actor = JsonSerializer.Deserialize<Actor>(actorAsSerializedJson);
        return actor;
    }

    private async Task<Actor> GetActorFromDatabase(GetActorQuery request, CancellationToken cancellationToken)
    {
        var actor = await context.Actors.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
        return actor;
    }
}