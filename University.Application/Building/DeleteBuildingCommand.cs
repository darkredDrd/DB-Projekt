using MediatR;

namespace Cinema.Application.Buildings;

public record DeleteBuildingCommand : IRequest
{
    public int Id { get; set; }
}