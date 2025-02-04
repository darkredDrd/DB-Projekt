using MediatR;

using Cinema.Models;

namespace Cinema.Application.Revenue;

public class CreateRevenueCommand : IRequest
{
    public int ScreeningId { get; set; }

    public float totalRevenue { get; set; }
}