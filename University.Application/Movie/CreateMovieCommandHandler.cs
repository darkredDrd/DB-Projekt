using MediatR;

using Cinema.Persistence;

namespace Cinema.Application.Movies;

public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand>
{
    private readonly CinemaContext context;

    public CreateMovieCommandHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = request.ToMovie();

        context.Add(movie);

        await context.SaveChangesAsync(cancellationToken);
    }
}

