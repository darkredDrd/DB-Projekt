using MediatR;

using Microsoft.EntityFrameworkCore;

using University.Models;
using University.Persistence;

namespace University.Application.Teachers;

public class GetTeachersQueryHandler : IRequestHandler<GetTeachersQuery, List<Movie>>
{
    private readonly UniversityContext context;

    public GetTeachersQueryHandler(UniversityContext context)
    {
        this.context = context;
    }

    public async Task<List<Movie>> Handle(GetTeachersQuery request, CancellationToken cancellationToken)
    {
        var teachers = await context.Teachers.ToListAsync(cancellationToken);
        return teachers;
    }
}