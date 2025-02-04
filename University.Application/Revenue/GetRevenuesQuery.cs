using MediatR;

using Cinema.Models;

namespace Cinema.Application.Revenues
{
    public class GetRevenuesQuery : IRequest<List<Revenue>>
    {
    }
}
