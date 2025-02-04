using MediatR;

using Microsoft.Extensions.Caching.Distributed;

using Cinema.Models;
using Cinema.Persistence;

namespace Cinema.Application.Revenues;

public class DeleteRevenueCommandHandler : IRequestHandler<DeleteRevenueCommand>
{
    private readonly CinemaContext context;
    private readonly IDistributedCache cache;

    public DeleteRevenueCommandHandler(CinemaContext context, IDistributedCache cache)
    {
        this.context = context;
        this.cache = cache;
    }

    public async Task Handle(DeleteRevenueCommand request, CancellationToken cancellationToken)
    {
        var revenue = await context.Revenues.FindAsync(request.Id, cancellationToken);
        if (revenue != null)
        {
            context.Revenues.Remove(revenue);
        }

        await context.SaveChangesAsync(cancellationToken);

        await this.InvalidateCache(revenue);
    }

    private async Task InvalidateCache(Revenue revenue)
    {
        var key = $"revenue-{revenue.Id}";
        await this.cache.RemoveAsync(key);
    }
}