using MediatR;
using University.Models;

namespace Cinema.Application.Actor
{
    public class GetStudentsQuery : IRequest<List<Revenue>>
    {
    }
}
