using MediatR;

using Microsoft.Extensions.Caching.Distributed;
using Cinema.Models;
using Cinema.Persistence;
using Cinema.Application.Actors;

namespace Cinema.Application.Actors;

public class DeleteActorCommandHandler : IRequestHandler<DeleteActorCommand>
{
    private readonly CinemaContext context;
    private readonly IDistributedCache cache;

    public DeleteActorCommandHandler(CinemaContext context, IDistributedCache cache)
    {
        this.context = context;
        this.cache = cache;
    }

    public async Task Handle(DeleteActorCommand request, CancellationToken cancellationToken)
    {
        var actor = await context.Actors.FindAsync(request.Id, cancellationToken);
        if (actor != null)
        {
            context.Students.Remove(actor);
        }

        await context.SaveChangesAsync(cancellationToken);

        await this.InvalidateCache(actor);
    }

    private async Task InvalidateCache(Actor actor)
    {
        var key = $"actor-{actor.Id}";
        await cache.RemoveAsync(key);
    }
}