using MediatR;

using University.Models;

namespace University.Application.Marks;

public class GetMarkQuery : IRequest<Hall>
{
    public int Id { get; set; }
}