using MediatR;

namespace Cinema.Application.Halls;

public class DeleteHallCommand : IRequest
{
    public int Id { get; set; }
}