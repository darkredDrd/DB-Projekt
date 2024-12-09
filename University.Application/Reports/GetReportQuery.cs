using MediatR;

using University.Models;

namespace University.Application.Reports
{
    public class GetReportQuery : IRequest<Report>
    {
    }
}
