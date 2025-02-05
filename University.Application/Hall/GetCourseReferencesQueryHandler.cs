using MediatR;

using Microsoft.EntityFrameworkCore;

using University.Persistence;

namespace University.Application.Marks;

public class GetScreeningReferencesQueryHandler : IRequestHandler<GetScreeningReferencesQuery, CourseReferences>
{
    private readonly UniversityContext context;

    public GetScreeningReferencesQueryHandler(UniversityContext context)
    {
        this.context = context;
    }

    public async Task<CourseReferences> Handle(GetScreeningReferencesQuery request, CancellationToken cancellationToken)
    {
        var allStudents = await context.Students.ToListAsync(cancellationToken);
        var allTeachers = await context.Teachers.ToListAsync(cancellationToken);

        return new CourseReferences
        {
            Students = allStudents,
            Teachers = allTeachers
        };
    }
}