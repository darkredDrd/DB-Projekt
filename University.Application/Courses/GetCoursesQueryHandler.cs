using MediatR;

using Microsoft.EntityFrameworkCore;

using University.Models;
using University.Persistence;

namespace University.Application.Courses;

public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, List<Course>>
{
    private readonly UniversityContext context;

    public GetCoursesQueryHandler(UniversityContext context)
    {
        this.context = context;
    }

    public async Task<List<Course>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        var courses = await context.Courses
            .Include(course => course.Students)
            .Include(course => course.Teachers)
            .ToListAsync(cancellationToken);
        return courses;
    }
}