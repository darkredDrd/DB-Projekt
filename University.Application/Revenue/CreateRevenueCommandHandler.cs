using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Models;
using Cinema.Persistence;

namespace Cinema.Application.Revenues;

public class CreateRevenueCommandHandler : IRequestHandler<CreateRevenueCommand>
{
    private readonly CinemaContext context;

    public CreateRevenueCommandHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task Handle(CreateRevenueCommand request, CancellationToken cancellationToken)
    {
        var screening = await context.Screenings.FirstOrDefaultAsync(s => s.Id == request.ScreeningId, cancellationToken);
        if (screening == null)
        {
            throw new NullReferenceException("Screening not found");
        }

        var revenue = new Revenue 
        {
            Screening = screening,
            TotalRevenue = request.TotalRevenue
        };

        context.Add(revenue);
        await context.SaveChangesAsync(cancellationToken);
    }
}
