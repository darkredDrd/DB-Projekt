using MediatR;

namespace Cinema.Application.Halls;

public class GetHallReferencesQuery : IRequest<HallReferences>
{
}