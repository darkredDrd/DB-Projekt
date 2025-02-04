using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Models;
using Cinema.Persistence;

namespace Cinema.Application.Screenings;

public class CreateScreeningCommandHandler : IRequestHandler<CreateScreeningCommand>
{
    private readonly CinemaContext context;

    public CreateScreeningCommandHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task Handle(CreateScreeningCommand request, CancellationToken cancellationToken)
    {
        var movie = await context.Screenings.FirstOrDefaultAsync(s => s.Id == request.MovieID, cancellationToken);
        if (movie == null)
        {
            throw new NullReferenceException("Movie not found");
        }

        var hall = await context.Screenings.FirstOrDefaultAsync(s => s.Id == request.HallID, cancellationToken);
        if (movie == null)
        {
            throw new NullReferenceException("Hall not found");
        }

        var screening = new Screening 
        {
            DateTime = request.DateTime,
            Movie = movie,
            Hall = hall
        };

        context.Add(screening);
        await context.SaveChangesAsync(cancellationToken);
    }
}
