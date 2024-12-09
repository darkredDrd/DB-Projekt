using MediatR;

using University.Models.Reports;

namespace University.Application.Reports
{
    public class GetReportsQuery : IRequest<List<MongoDbReport>>
    {
    }
}
