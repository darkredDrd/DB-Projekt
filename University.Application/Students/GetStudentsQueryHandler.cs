using MediatR;

using Microsoft.EntityFrameworkCore;

using University.Models;
using University.Persistence;

namespace University.Application.Students;

public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<Revenue>>
{
    private readonly UniversityContext context;

    public GetStudentsQueryHandler(UniversityContext context)
    {
        this.context = context;
    }

    public async Task<List<Revenue>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = await context.Students.ToListAsync(cancellationToken);
        return students;
    }
}