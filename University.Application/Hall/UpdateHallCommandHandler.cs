using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Persistence;

namespace Cinema.Application.Hall;

public class UpdateHallCommandHandler : IRequestHandler<UpdateHallCommand>
{
    private readonly CinemaContext context;

    public UpdateHallCommandHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task Handle(UpdateHallCommand request, CancellationToken cancellationToken)
    {
        var existingHall = await context.Halls
            .Include(hall => hall.Building)
            .FirstOrDefaultAsync(hall => hall.Id == request.Id, cancellationToken);

        if (existingHall == null)
        {
            throw new NullReferenceException("Hall not found");
        }

        var building = await context.Buildings.FirstOrDefaultAsync(c => c.Id == request.BuildingId, cancellationToken);
        if (building == null)
        {
            throw new NullReferenceException("Building not found");
        }

        existingHall.Name = request.Name;
        existingHall.Seats = request.Seats;
        existingHall.Building = building;

        await context.SaveChangesAsync(cancellationToken);
    }
}