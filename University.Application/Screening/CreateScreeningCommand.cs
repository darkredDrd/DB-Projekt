using MediatR;

namespace Cinema.Application.Screenings;

public class CreateScreeningCommand : IRequest
{
    public DateTime DateTime { get; set; }
    public int MovieID { get; set; }
    public int HallID { get; set; }

}