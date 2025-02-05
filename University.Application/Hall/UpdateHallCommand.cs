using MediatR;

namespace Cinema.Application.Hall;

public class UpdateHallCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Seats { get; set; }
    public int CinemaId { get; set; }
}