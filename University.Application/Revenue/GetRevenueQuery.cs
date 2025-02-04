using MediatR;

using Cinema.Models;

namespace Cinema.Application.Students;

public class GetRevenueQuery : IRequest<Revenue>
{
    public int Id { get; set; }
}