using MediatR;

namespace Cinema.Application.Marks;

public class UpdateMarkCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Seats { get; set; }
    public int CinemaId { get; set; }
}