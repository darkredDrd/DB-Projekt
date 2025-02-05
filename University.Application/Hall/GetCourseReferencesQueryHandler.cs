using MediatR;

using Microsoft.EntityFrameworkCore;

using Cinema.Persistence;

namespace Cinema.Application.Marks;

public class GetCourseReferencesQueryHandler : IRequestHandler<GetCourseReferencesQuery, CourseReferences>
{
    private readonly CinemaContext context;

    public GetCourseReferencesQueryHandler(CinemaContext context)
    {
        this.context = context;
    }

    public async Task<CourseReferences> Handle(GetCourseReferencesQuery request, CancellationToken cancellationToken)
    {
        var allCinemas = await context.Cinemas.ToListAsync(cancellationToken);

        return new CourseReferences
        {
            Cinemas = allCinemas
        };
    }
}