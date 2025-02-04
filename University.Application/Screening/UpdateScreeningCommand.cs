using MediatR;

using Cinema.Models;

namespace Cinema.Application.Screenings;

public class UpdateScreeningCommand : IRequest
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int HallId { get; set; }
    public DateTime DateTime { get; set; }

}