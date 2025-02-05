using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Models;
using Cinema.Persistence;

namespace Cinema.Application.Hall;

public class CreateHallCommandHandler : IRequestHandler<CreateHallCommand>
{
    private readonly CinemaContext context;

    public CreateHallCommandHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task Handle(CreateHallCommand request, CancellationToken cancellationToken)
    {
        var cinema = await context.Cinemas.FirstOrDefaultAsync(c => c.Id == request.CinemaId, cancellationToken);
        if (cinema == null)
        {
            throw new NullReferenceException("Cinema not found");
        }

        var hall = new Hall
        {
            Name = request.Name,
            Seats = request.Seats,
            Cinema = cinema
        };

        context.Add(hall);
        await context.SaveChangesAsync(cancellationToken);
    }
}