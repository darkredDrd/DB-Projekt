using MediatR;

using Cinema.Models;

namespace Cinema.Application.Marks;

public class GetMarksListQuery : IRequest<List<Hall>>
{
}