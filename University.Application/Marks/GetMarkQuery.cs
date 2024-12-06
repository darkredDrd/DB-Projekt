using MediatR;

using University.Models;

namespace University.Application.Marks;

public class GetMarkQuery : IRequest<Mark>
{
    public int Id { get; set; }
}