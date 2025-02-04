using MediatR;

using University.Models;

namespace University.Application.Marks;

public class GetMarksListQuery : IRequest<List<Hall>>
{
}