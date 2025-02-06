using MediatR;

using Microsoft.Extensions.Caching.Distributed;

using Cinema.Models;
using Cinema.Persistence;

namespace Cinema.Application.Screenings;

public class DeleteScreeningCommandHandler : IRequestHandler<DeleteScreeningCommand>
{
    private readonly CinemaContext context;
    private readonly IDistributedCache cache;

    public DeleteScreeningCommandHandler(CinemaContext context, IDistributedCache cache)
    {
        this.context = context;
        this.cache = cache;
    }

    public async Task Handle(DeleteScreeningCommand request, CancellationToken cancellationToken)
    {
        var screening = await context.Screenings.FindAsync(request.Id, cancellationToken);
        if (screening != null)
        {
            context.Screenings.Remove(screening);
        }

        await context.SaveChangesAsync(cancellationToken);

        await this.InvalidateCache(screening);
    }

    private async Task InvalidateCache(Screening screening)
    {
        var key = $"screening-{screening.Id}";
        await this.cache.RemoveAsync(key);
    }
}