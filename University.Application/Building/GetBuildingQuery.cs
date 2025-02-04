using MediatR;

using Cinema.Models;

namespace Cinema.Application.Buildings;

public class GetBuildingQuery : IRequest<Building>
{
    public int Id;
}