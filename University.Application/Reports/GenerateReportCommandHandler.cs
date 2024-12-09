using MediatR;

using Microsoft.EntityFrameworkCore;

using MongoDB.Driver;

using University.Models;
using University.Models.Reports;
using University.Persistence;

namespace University.Application.Reports;

public class GenerateReportCommandHandler : IRequestHandler<GenerateReportCommand>
{
    private readonly UniversityContext context;
    private readonly MongoDatabaseBase mongoDatabase;

    public GenerateReportCommandHandler(UniversityContext context, MongoDatabaseBase mongoDatabase)
    {
        this.context = context;
        this.mongoDatabase = mongoDatabase;
    }

    public async Task Handle(GenerateReportCommand request, CancellationToken cancellationToken)
    {
        var students = await context.Students
            .Include(student => student.Marks)
            .ThenInclude(mark => mark.Course)
            .Include(student => student.Marks)
            .ThenInclude(mark => mark.Teacher)
            .ToListAsync(cancellationToken);

        var report = new Report
        {
            GeneratedDate = DateTime.UtcNow,
            Students = students
        };

        var reportCollection = mongoDatabase.GetCollection<MongoDbReport>("reports");
        await reportCollection.InsertOneAsync(MongoDbReport.FromReport(report), options: null, cancellationToken);
    }
}