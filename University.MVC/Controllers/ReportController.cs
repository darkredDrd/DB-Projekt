using MediatR;

using Microsoft.AspNetCore.Mvc;

using University.Application.Reports;
using University.MVC.ViewModels.Reports;

namespace University.MVC.Controllers
{
    public class ReportController : Controller
    {
        private readonly IMediator mediator;

        public ReportController(IMediator mediator)
        {
            this.mediator = mediator;
        }

       public async Task<IActionResult> Index()
        {
            var getReportQuery = new GetReportQuery();
            var report = await this.mediator.Send(getReportQuery);

            var reportListViewModel = ReportListViewModel.FromReport(report);
            
            return View(reportListViewModel);
        }
    }
}
