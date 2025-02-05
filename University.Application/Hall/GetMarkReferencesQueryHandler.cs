using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Persistence;

namespace Cinema.Application.Marks;

public class GetMarkReferencesQueryHandler : IRequestHandler<GetMarkReferencesQuery, MarkReferences>
{
    private readonly CinemaContext context;

    public GetMarkReferencesQueryHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task<MarkReferences> Handle(GetMarkReferencesQuery request, CancellationToken cancellationToken)
    {
        var allCinemas = await context.Cinemas.ToListAsync(cancellationToken);

        return new MarkReferences
        {
            Cinemas = allCinemas
        };
    }
}