using MediatR;

using Microsoft.EntityFrameworkCore;

using University.Models;
using University.Persistence;

namespace University.Application.Teachers;

public class GetTeacherQueryHandler : IRequestHandler<GetTeacherQuery, Movie>
{
    private readonly UniversityContext context;

    public GetTeacherQueryHandler(UniversityContext context)
    {
        this.context = context;
    }

    public async Task<Movie> Handle(GetTeacherQuery request, CancellationToken cancellationToken)
    {
        var teacher = await context.Teachers.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
        return teacher;
    }
}