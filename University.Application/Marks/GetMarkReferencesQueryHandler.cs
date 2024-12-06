using MediatR;

using Microsoft.EntityFrameworkCore;

using University.Persistence;

namespace University.Application.Marks;

public class GetMarkReferencesQueryHandler : IRequestHandler<GetMarkReferencesQuery, MarkReferences>
{
    private readonly UniversityContext context;

    public GetMarkReferencesQueryHandler(UniversityContext context)
    {
        this.context = context;
    }

    public async Task<MarkReferences> Handle(GetMarkReferencesQuery request, CancellationToken cancellationToken)
    {
        var allCourses = await context.Courses.ToListAsync(cancellationToken);
        var allStudents = await context.Students.ToListAsync(cancellationToken);
        var allTeachers = await context.Teachers.ToListAsync(cancellationToken);

        return new MarkReferences
        {
            Courses = allCourses,
            Students = allStudents,
            Teachers = allTeachers
        };
    }
}