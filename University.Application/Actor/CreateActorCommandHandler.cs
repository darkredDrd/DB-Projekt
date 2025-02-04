using MediatR;
using Cinema.Persistence;

namespace Cinema.Application.Actors;

public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand>
{
    private readonly CinemaContext context;

    public CreateActorCommandHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task Handle(CreateActorCommand request, CancellationToken cancellationToken)
    {
        var actor = request.ToActor();

        context.Add(actor);

        await context.SaveChangesAsync(cancellationToken);
    }
}