using MediatR;

using Microsoft.Build.Framework;
using Microsoft.Extensions.Caching.Distributed;
using Cinema.Models;
using Cinema.Persistence;

namespace Cinema.Application.Actors;

public class UpdateActorCommandHandler : IRequestHandler<UpdateActorCommand>
{
    private readonly CinemaContext context;
    private readonly IDistributedCache cache;

    public UpdateActorCommandHandler(CinemaContext context, IDistributedCache cache)
    {
        this.context = context;
        this.cache = cache;
    }

    public async Task Handle(UpdateActorCommand request, CancellationToken cancellationToken)
    {
        var actor = request.ToActor();

        context.Update(actor);

        await context.SaveChangesAsync(cancellationToken);

        await InvalidateCache(actor);
    }

    private async Task InvalidateCache(Actor actor)
    {
        var key = $"actor-{actor.Id}";
        await cache.RemoveAsync(key);
    }
}