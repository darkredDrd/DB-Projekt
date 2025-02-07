//using MediatR;

//using Microsoft.EntityFrameworkCore;

//using MongoDB.Driver;

//using Cinema.Models;
//using Cinema.Models.Reports;
//using Cinema.Persistence;

//namespace Cinema.Application.Reports;

//public class GenerateReportCommandHandler : IRequestHandler<GenerateReportCommand>
//{
//    private readonly CinemaContext context;
//    private readonly MongoDatabaseBase mongoDatabase;

//    public GenerateReportCommandHandler(CinemaContext context, MongoDatabaseBase mongoDatabase)
//    {
//        this.context = context;
//        this.mongoDatabase = mongoDatabase;
//    }

//    public async Task Handle(GenerateReportCommand request, CancellationToken cancellationToken)
//    {
//        var students = await context.Students
//            .Include(student => student.Marks)
//            .ThenInclude(mark => mark.Course)
//            .Include(student => student.Marks)
//            .ThenInclude(mark => mark.Teacher)
//            .ToListAsync(cancellationToken);

//        var report = new Screening
//        {
//            GeneratedDate = DateTime.UtcNow,
//            Students = students
//        };

//        var reportCollection = mongoDatabase.GetCollection<MongoDbReport>("reports");
//        await reportCollection.InsertOneAsync(MongoDbReport.FromReport(report), options: null, cancellationToken);
//    }
//}