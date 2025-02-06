using MediatR;

using Microsoft.AspNetCore.Mvc;

using Cinema.Application.Halls;
using Cinema.MVC.ViewModels.Halls;

namespace Cinema.MVC.Controllers
{
    public class HallsController : Controller
    {
        private readonly IMediator mediator;

        public HallsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: HallsController
        public async Task<ActionResult> Index()
        {
            var getHallListQuery = new GetHallListQuery();
            var halls = await mediator.Send(getHallListQuery);

            var hallListViewModels = halls.Select(HallListViewModel.FromHall);

            return View(hallListViewModels);
        }

        // GET: HallsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var getHallQuery = new GetHallQuery { Id = id };
            var hall = await mediator.Send(getHallQuery);

            var hallDetailsViewModel = HallDetailsViewModel.FromHall(hall);

            return View(hallDetailsViewModel);
        }

        // GET: HallsController/Create
        public async Task<ActionResult> Create()
        {
            var getHallReferencesQuery = new GetHallReferencesQuery();
            var hallReferences = await this.mediator.Send(getHallReferencesQuery);

            var hallCreateViewModel = new HallCreateViewModel(hallReferences.Buildings);

            return View(hallCreateViewModel);
        }

        // POST: HallsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HallCreateViewModel hallCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var createHallCommand = hallCreateViewModel.ToCommand();
                
                await mediator.Send(createHallCommand);

                return RedirectToAction(nameof(Index));
            }

            return View(hallCreateViewModel);
        }

        // GET: HallsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var getHallReferencesQuery = new GetHallReferencesQuery();
            var hallReferences = await this.mediator.Send(getHallReferencesQuery);

            var getHallQuery = new GetHallQuery { Id = id };
            var hall = await mediator.Send(getHallQuery);

            var hallUpdateViewModel = new HallUpdateViewModel(hall, hallReferences.Buildings);

            return View(hallUpdateViewModel);
        }

        // POST: HallsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, HallUpdateViewModel hallUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                var updateHallCommand = hallUpdateViewModel.ToCommand();

                await mediator.Send(updateHallCommand);

                return RedirectToAction(nameof(Index));
            }

            return View(hallUpdateViewModel);
        }

        // GET: HallsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var getHallQuery = new GetHallQuery { Id = id };
            var hall = await mediator.Send(getHallQuery);

            var hallDetailsViewModel = HallDetailsViewModel.FromHall(hall);

            return View(hallDetailsViewModel);
        }

        // POST: HallsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleteHallCommand = new DeleteHallCommand { Id = id };

            await mediator.Send(deleteHallCommand);
            
            return RedirectToAction(nameof(Index));
        }
    }
}