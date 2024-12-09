using MediatR;

using Microsoft.EntityFrameworkCore;

using University.Models;
using University.Persistence;

namespace University.Application.Courses;

public class GetCourseQueryHandler : IRequestHandler<GetCourseQuery, Course>
{
    private readonly UniversityContext context;

    public GetCourseQueryHandler(UniversityContext context)
    {
        this.context = context;
    }

    public async Task<Course> Handle(GetCourseQuery request, CancellationToken cancellationToken)
    {
        var course = await context.Courses
            .Include(course => course.Students)
            .Include(course => course.Teachers)
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        return course;
    }
}