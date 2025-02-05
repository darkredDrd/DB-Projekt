using MediatR;

using Cinema.Persistence;

namespace Cinema.Application.Marks;

public class DeleteMarkCommandHandler : IRequestHandler<DeleteMarkCommand>
{
    private readonly CinemaContext context;

    public DeleteMarkCommandHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task Handle(DeleteMarkCommand request, CancellationToken cancellationToken)
    {
        var hall = await context.Halls.FindAsync(request.Id, cancellationToken);
        if (hall != null)
        {
            context.Halls.Remove(hall);
        }

        await context.SaveChangesAsync(cancellationToken);
    }
}