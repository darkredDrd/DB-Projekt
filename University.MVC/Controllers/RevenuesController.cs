using MediatR;

using Microsoft.AspNetCore.Mvc;

using Cinema.Application.Revenues;
using Cinema.MVC.ViewModels.Revenues;

namespace Cinema.MVC.Controllers
{
    public class RevenuesController : Controller
    {
        private readonly IMediator mediator;

        public RevenuesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: RevenuesController
        public async Task<IActionResult> Index()
        {
            var getRevenuesQuery = new GetRevenuesQuery();
            var revenues = await this.mediator.Send(getRevenuesQuery);

            var revenueListViewModels = revenues.Select(RevenueListViewModel.FromActor).ToList();

            return View(revenueListViewModels);
        }

        // GET: RevenuesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var getRevenueQuery = new GetRevenueQuery { Id = id };
            var revenue = await mediator.Send(getRevenueQuery);

            var revenueDetailsViewModel = RevenueDetailsViewModel.FromRevenue(revenue);

            return View(revenueDetailsViewModel);
        }

        // GET: RevenuesController/Create
        public async Task<ActionResult> Create()
        {
            var getRevenueReferencesQuery = new GetRevenueReferencesQuery();
            var revenueReferences = await this.mediator.Send(getRevenueReferencesQuery);

            var revenueCreateViewModel = new RevenueCreateViewModel(revenueReferences.Screenings);

            return View(revenueCreateViewModel);
        }

        // POST: RevenueController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RevenueCreateViewModel revenueCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var createRevenueCommand = revenueCreateViewModel.ToCommand();
                
                await mediator.Send(createRevenueCommand);

                return RedirectToAction(nameof(Index));
            }

            return View(revenueCreateViewModel);
        }

        // GET: RevenuesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var getRevenueReferencesQuery = new GetRevenueReferencesQuery();
            var revenueReferences = await this.mediator.Send(getRevenueReferencesQuery);

            var getRevenueQuery = new GetRevenueQuery { Id = id };
            var revenue = await mediator.Send(getRevenueQuery);

            var revenueUpdateViewModel = new RevenueUpdateViewModel(revenue, revenueReferences.Screenings);

            return View(revenueUpdateViewModel);
        }

        // POST: RevenuesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, RevenueUpdateViewModel revenueUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                var updateRevenueCommand = revenueUpdateViewModel.ToCommand();

                await mediator.Send(updateRevenueCommand);

                return RedirectToAction(nameof(Index));
            }

            return View(revenueUpdateViewModel);
        }

        // GET: RevenuesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var getRevenueQuery = new GetRevenueQuery { Id = id };
            var revenue = await mediator.Send(getRevenueQuery);

            var revenueDetailsViewModel = RevenueDetailsViewModel.FromRevenue(revenue);

            return View(revenueDetailsViewModel);
        }

        // POST: RevenuesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleteRevenueCommand = new DeleteRevenueCommand { Id = id };

            await mediator.Send(deleteRevenueCommand);
            
            return RedirectToAction(nameof(Index));
        }
    }
}