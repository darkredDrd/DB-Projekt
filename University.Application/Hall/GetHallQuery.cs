using MediatR;

using Cinema.Models;

namespace Cinema.Application.Hall;

public class GetHallQuery : IRequest<Hall>
{
    public int Id { get; set; }
}