using MediatR;

using Microsoft.Build.Framework;
using Microsoft.Extensions.Caching.Distributed;

using Cinema.Models;
using Cinema.Persistence;

namespace Cinema.Application.Screenings;

public class UpdateScreeningCommandHandler : IRequestHandler<UpdateScreeningCommand>
{
    private readonly CinemaContext context;

    public UpdateScreeningCommandHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task Handle(UpdateScreeningCommand request, CancellationToken cancellationToken)
    {
        var existingScreening = await context.Screenings
            .Include(screening => screening.Movie)
            .include(Screening => Screening.Hall)
            .FirstOrDefaultAsync(screening => screening.Id == request.Id, cancellationToken);

        if (existingScreening == null)
        {
            throw new NullReferenceException("Screening not found");
        }

        var movie = await context.Movies.FirstOrDefaultAsync(s => s.Id == request.MovieId, cancellationToken);
        if (movie == null)
        {
            throw new NullReferenceException("Movie not found");
        }

        var hall = await context.Movies.FirstOrDefaultAsync(s => s.Id == request.HallId, cancellationToken);
        if (hall == null)
        {
            throw new NullReferenceException("Hall not found");
        }

        existingScreening.Movie = movie;
        existingScreening.Hall = hall;
        existingScreening.DateTime = request.DateTime;

        await context.SaveChangesAsync(cancellationToken);
    }
}