using MediatR;

using Microsoft.AspNetCore.Mvc;

using Cinema.Application.Screenings;
using Cinema.MVC.ViewModels.Screenings;

namespace Cinema.MVC.Controllers
{
    public class ScreeningsController : Controller
    {
        private readonly IMediator mediator;

        public ScreeningsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: ScreeningsController
        public async Task<IActionResult> Index()
        {
            var getScreeningsQuery = new GetScreeningsQuery();
            var screenings = await this.mediator.Send(getScreeningsQuery);

            var screeningListViewModels = screenings.Select(ScreeningListViewModel.FromScreening).ToList();

            return View(screeningListViewModels);
        }

        // GET: ScreeningsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var getScreeningQuery = new GetScreeningQuery { Id = id };
            var screening = await mediator.Send(getScreeningQuery);

            var screeningDetailsViewModel = ScreeningDetailsViewModel.FromScreening(screening);

            return View(screeningDetailsViewModel);
        }

        // GET: ScreeningsController/Create
        public async Task<ActionResult> Create()
        {
            var getScreeningReferencesQuery = new GetScreeningReferencesQuery();
            var screeningReferences = await this.mediator.Send(getScreeningReferencesQuery);

            var screeningCreateViewModel = new ScreeningCreateViewModel(screeningReferences.Movies);

            return View(screeningCreateViewModel);
        }

        // POST: ScreeningController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ScreeningCreateViewModel screeningCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var createScreeningCommand = screeningCreateViewModel.ToCommand();

                await mediator.Send(createScreeningCommand);

                return RedirectToAction(nameof(Index));
            }

            return View(screeningCreateViewModel);
        }

        // GET: ScreeningsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var getScreeningReferencesQuery = new GetScreeningReferencesQuery();
            var screeningReferences = await this.mediator.Send(getScreeningReferencesQuery);

            var getScreeningQuery = new GetScreeningQuery { Id = id };
            var screening = await mediator.Send(getScreeningQuery);

            var screeningUpdateViewModel = new ScreeningUpdateViewModel(screening, screeningReferences.Movies);

            return View(screeningUpdateViewModel);
        }

        // POST: ScreeningsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ScreeningUpdateViewModel screeningUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                var updateScreeningCommand = screeningUpdateViewModel.ToCommand();

                await mediator.Send(updateScreeningCommand);

                return RedirectToAction(nameof(Index));
            }

            return View(screeningUpdateViewModel);
        }

        // GET: ScreeningsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var getScreeningQuery = new GetScreeningQuery { Id = id };
            var screening = await mediator.Send(getScreeningQuery);
            var screeningDetailsViewModel = ScreeningDetailsViewModel.FromScreening(screening);

            return View(screeningDetailsViewModel);
        }

        // POST: ScreeningsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleteScreeningCommand = new DeleteScreeningCommand { Id = id };

            await mediator.Send(deleteScreeningCommand);

            return RedirectToAction(nameof(Index));
        }
    }
}