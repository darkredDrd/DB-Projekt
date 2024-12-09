using MediatR;

using University.Models;

namespace University.Application.Teachers
{
    public class GetTeachersQuery : IRequest<List<Teacher>>
    {
    }
}
