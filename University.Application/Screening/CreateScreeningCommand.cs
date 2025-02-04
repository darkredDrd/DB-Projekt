using MediatR;

namespace Cinema.Application.Screening;

public class CreateScreeningCommand : IRequest
{
    public string DateTime { get; set; }
    public int MovieID { get; set; }
    public int HallID { get; set; }

}