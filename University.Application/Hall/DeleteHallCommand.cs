using MediatR;

namespace Cinema.Application.Hall;

public class DeleteHallCommand : IRequest
{
    public int Id { get; set; }
}