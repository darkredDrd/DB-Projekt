using MediatR;

using Microsoft.EntityFrameworkCore;

using University.Models;
using University.Persistence;

namespace University.Application.Students;

public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, Student>
{
    private readonly UniversityContext context;

    public GetStudentQueryHandler(UniversityContext context)
    {
        this.context = context;
    }

    public async Task<Student> Handle(GetStudentQuery request, CancellationToken cancellationToken)
    {
        var student = await context.Students.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
        return student;
    }
}