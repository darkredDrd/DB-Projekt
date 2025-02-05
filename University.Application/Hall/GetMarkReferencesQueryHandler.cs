using MediatR;

using Microsoft.EntityFrameworkCore;

using University.Persistence;

namespace University.Application.Marks;

public class GetRevenueReferencesQueryHandler : IRequestHandler<GetMarkReferencesQuery, RevenueReferences>
{
    private readonly UniversityContext context;

    public GetRevenueReferencesQueryHandler(UniversityContext context)
    {
        this.context = context;
    }

    public async Task<RevenueReferences> Handle(GetMarkReferencesQuery request, CancellationToken cancellationToken)
    {
        var allCourses = await context.Courses.ToListAsync(cancellationToken);
        var allStudents = await context.Students.ToListAsync(cancellationToken);
        var allTeachers = await context.Teachers.ToListAsync(cancellationToken);

        return new RevenueReferences
        {
            Courses = allCourses,
            Students = allStudents,
            Teachers = allTeachers
        };
    }
}