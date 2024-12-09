using MediatR;

using Microsoft.AspNetCore.Mvc;

using University.Application.Reports;

namespace University.MVC.Controllers
{
    public class ReportController : Controller
    {
        private readonly IMediator mediator;

        public ReportController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("generate-report")]
        public async Task<IActionResult> GenerateReport()
        {
            var generateReportCommand = new GenerateReportCommand();
            await mediator.Send(generateReportCommand);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Index()
        {
            var getReportsQuery = new GetReportsQuery();
            var reports = await this.mediator.Send(getReportsQuery);

            return View(reports);
        }
    }
}
