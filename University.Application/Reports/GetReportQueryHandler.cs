using MediatR;

using MongoDB.Driver;

using University.Models.Reports;

namespace University.Application.Reports;

public class GetReportsQueryHandler : IRequestHandler<GetReportsQuery, List<MongoDbReport>>
{
    private readonly MongoDatabaseBase mongoDatabase;


    public GetReportsQueryHandler(MongoDatabaseBase mongoDatabase)
    {
        this.mongoDatabase = mongoDatabase;
    }

    public async Task<List<MongoDbReport>> Handle(GetReportsQuery request, CancellationToken cancellationToken)
    {
        var reportCollection = mongoDatabase.GetCollection<MongoDbReport>("reports");

        return await reportCollection.AsQueryable().ToListAsync(cancellationToken);
    }
}