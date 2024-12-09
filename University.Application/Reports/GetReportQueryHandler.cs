using MediatR;

using Microsoft.EntityFrameworkCore;

using University.Models;
using University.Persistence;

namespace University.Application.Reports;

public class GetReportQueryHandler : IRequestHandler<GetReportQuery, Report>
{
    private readonly UniversityContext context;

    public GetReportQueryHandler(UniversityContext context)
    {
        this.context = context;
    }

    public async Task<Report> Handle(GetReportQuery request, CancellationToken cancellationToken)
    {
        var students = await context.Students
            .Include(student => student.Courses)
            .Include(student => student.Marks)
            .ThenInclude(mark => mark.Teacher)
            .ToListAsync(cancellationToken);

        return new Report
        {
            GeneratedDate = DateTime.UtcNow,
            Students = students
        };
    }
}