using MediatR;

using Cinema.Models;

namespace Cinema.Application.Buildings;

public class GetBuildingsQuery : IRequest<List<Building>>
{

}