using MediatR;

using Cinema.Models;

namespace Cinema.Application.Revenues;

public class GetRevenueQuery : IRequest<Revenue>
{
    public int Id { get; set; }
}