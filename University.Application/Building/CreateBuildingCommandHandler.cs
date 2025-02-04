using MediatR;

using Cinema.Persistence;

namespace Cinema.Application.Buildings;

public class CreateBuildingCommandHandler : IRequestHandler<CreateBuildingCommand>
{
    private readonly CinemaContext context;

    public CreateBuildingCommandHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
    {
        var building = request.ToBuilding();
        context.Buildings.Add(building);

        await context.SaveChangesAsync(cancellationToken);
    }
}