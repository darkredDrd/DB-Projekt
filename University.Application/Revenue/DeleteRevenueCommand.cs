using MediatR;

namespace Cinema.Application.Revenues;

public class DeleteRevenueCommand : IRequest
{
    public int Id { get; set; }
}