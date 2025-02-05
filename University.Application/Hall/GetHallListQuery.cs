using MediatR;

using Cinema.Models;

namespace Cinema.Application.Hall;

public class GetHallListQuery : IRequest<List<Hall>>
{
}