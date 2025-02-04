using MediatR;

namespace Cinema.Application.Students;

public class DeleteRevenueCommand : IRequest
{
    public int Id { get; set; }
}