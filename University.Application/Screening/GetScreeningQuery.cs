using MediatR;

using Cinema.Models;

namespace Cinema.Application.Screenings;

public class GetScreeningQuery : IRequest<Screening>
{
    public int Id { get; set; }
}