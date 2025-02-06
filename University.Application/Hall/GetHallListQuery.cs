using MediatR;

using Cinema.Models;

namespace Cinema.Application.Halls;

public class GetHallListQuery : IRequest<List<Hall>>
{
}