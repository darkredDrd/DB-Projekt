using MediatR;

using Cinema.Models;

namespace Cinema.Application.Revenues;

public class UpdateRevenueCommand : IRequest
{
    public int Id { get; set; }

    public int ScreeningId { get; set; }

    public float TotalRevenue { get; set; }
}