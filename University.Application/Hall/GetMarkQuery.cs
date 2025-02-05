using MediatR;

using Cinema.Models;

namespace Cinema.Application.Marks;

public class GetMarkQuery : IRequest<Hall>
{
    public int Id { get; set; }
}