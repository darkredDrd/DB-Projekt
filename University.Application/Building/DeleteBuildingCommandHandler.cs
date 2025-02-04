using MediatR;

using Cinema.Persistence;

namespace Cinema.Application.Buildings;

public class DeleteBuildingCommandHandler : IRequestHandler<DeleteBuildingCommand>
{
    private readonly CinemaContext context;

    public DeleteBuildingCommandHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
    {
        var building = await context.Buildings.FindAsync(request.Id, cancellationToken);
        if (building != null)
        {
            context.Buildings.Remove(building);
        }

        await context.SaveChangesAsync(cancellationToken);
    }
}