using MediatR;

using Microsoft.Build.Framework;
using Microsoft.Extensions.Caching.Distributed;

using Cinema.Models;
using Cinema.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Application.Revenues;

public class UpdateRevenueCommandHandler : IRequestHandler<UpdateRevenueCommand>
{
    private readonly CinemaContext context;

    public UpdateRevenueCommandHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task Handle(UpdateRevenueCommand request, CancellationToken cancellationToken)
    {
        var existingRevenue = await context.Revenues
            .Include(revenue => revenue.Screening)
            .FirstOrDefaultAsync(revenue => revenue.Id == request.Id, cancellationToken);

        if (existingRevenue == null)
        {
            throw new NullReferenceException("Revenue not found");
        }

        var screening = await context.Screenings.FirstOrDefaultAsync(s => s.Id == request.ScreeningId, cancellationToken);
        if (screening == null)
        {
            throw new NullReferenceException("Screening not found");
        }

        existingRevenue.Screening = screening;
        existingRevenue.TotalRevenue = request.TotalRevenue;

        await context.SaveChangesAsync(cancellationToken);
    }
}