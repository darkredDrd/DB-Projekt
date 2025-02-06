using MediatR;

using Cinema.Models;

namespace Cinema.Application.Halls;

public class GetHallQuery : IRequest<Hall>
{
    public int Id { get; set; }
}