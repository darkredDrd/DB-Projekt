using MediatR;

using Cinema.Persistence;

namespace Cinema.Application.Movies;

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
{
    private readonly CinemaContext context;

    public UpdateMovieCommandHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = request.ToMovie();

        context.Add(movie);

        await context.SaveChangesAsync(cancellationToken);
    }
}