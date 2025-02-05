using MediatR;

using Cinema.Persistence;

namespace Cinema.Application.Hall;

public class DeleteHallCommandHandler : IRequestHandler<DeleteHallCommand>
{
    private readonly CinemaContext context;

    public DeleteHallCommandHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task Handle(DeleteHallCommand request, CancellationToken cancellationToken)
    {
        var hall = await context.Halls.FindAsync(request.Id, cancellationToken);
        if (hall != null)
        {
            context.Halls.Remove(hall);
        }

        await context.SaveChangesAsync(cancellationToken);
    }
}