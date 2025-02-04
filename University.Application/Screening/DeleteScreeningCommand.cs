using MediatR;

namespace Cinema.Application.Screenings;

public class DeleteScreeningCommand : IRequest
{
    public int Id { get; set; }
}