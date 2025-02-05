using MediatR;

using Microsoft.Extensions.Caching.Distributed;

using Cinema.Models;
using Cinema.Persistence;

namespace Cinema.Application.Revenues;

public class DeleteRevenueCommandHandler : IRequestHandler<DeleteRevenueCommand>
{
    private readonly CinemaContext context;

    public DeleteRevenueCommandHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task Handle(DeleteRevenueCommand request, CancellationToken cancellationToken)
    {
        var revenue = await context.Revenues.FindAsync(request.Id, cancellationToken);
        if (revenue != null)
        {
            context.Revenues.Remove(revenue);
        }

        await context.SaveChangesAsync(cancellationToken);
    }
}