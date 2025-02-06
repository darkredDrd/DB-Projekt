using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Models;
using Cinema.Persistence;

namespace Cinema.Application.Halls;

public class CreateHallCommandHandler : IRequestHandler<CreateHallCommand>
{
    private readonly CinemaContext context;

    public CreateHallCommandHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task Handle(CreateHallCommand request, CancellationToken cancellationToken)
    {
        var building = await context.Buildings.FirstOrDefaultAsync(c => c.Id == request.BuildingId, cancellationToken);
        if (building == null)
        {
            throw new NullReferenceException("Building not found");
        }

        var hall = new Hall
        {
            Name = request.Name,
            Seats = request.Seats,
            Building = building
        };

        context.Add(hall);
        await context.SaveChangesAsync(cancellationToken);
    }
}