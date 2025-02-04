using MediatR;
using Cinema.Persistence;

namespace Cinema.Application.Movies;

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
{
    private readonly CinemaContext context;

    public DeleteMovieCommandHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await context.Movies.FindAsync(request.Id, cancellationToken);
        if (movie != null)
        {
            context.Movies.Remove(movie);
        }

        await context.SaveChangesAsync(cancellationToken);
    }
}