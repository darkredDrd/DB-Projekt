using MediatR;

using Microsoft.AspNetCore.Mvc;

using Cinema.Application.Actors;
using Cinema.MVC.ViewModels.Actors;

namespace Cinema.MVC.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IMediator mediator;

        public ActorsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: Actors
        public async Task<IActionResult> Index()
        {
            var getActorsQuery = new GetActorsQuery();
            var actors = await this.mediator.Send(getActorsQuery);

            var actorListViewModels = actors.Select(ActorListViewModel.FromActor).ToList();

            return View(actorListViewModels);
        }

        // GET: Actors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getActorQuery = new GetActorQuery { Id = id.Value };
            var actor = await this.mediator.Send(getActorQuery);

            if (actor == null)
            {
                return NotFound();
            }

            var actorDetailsViewModel = ActorDetailsViewModel.FromActor(actor);

            return View(actorDetailsViewModel);
        }

        // GET: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ActorCreateViewModel actorCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var createActorCommand = actorCreateViewModel.ToCreateActorCommand();
                await mediator.Send(createActorCommand);

                return RedirectToAction(nameof(Index));
            }
            return View(actorCreateViewModel);
        }

        // GET: Actors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getActorQuery = new GetActorQuery { Id = id.Value };
            var actor = await this.mediator.Send(getActorQuery);

            var actorUpdateViewModel = ActorUpdateViewModel.FromActor(actor);
            return View(actorUpdateViewModel);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ActorUpdateViewModel actorUpdateViewModel)
        {
            if (id != actorUpdateViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var updateActorCommand = actorUpdateViewModel.ToUpdateActorCommand();
                await this.mediator.Send(updateActorCommand);
                
                return RedirectToAction(nameof(Index));
            }
            return View(actorUpdateViewModel);
        }

        // GET: Actors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getActorQuery = new GetActorQuery { Id = id.Value };
            var actor = await this.mediator.Send(getActorQuery);
            if (actor == null)
            {
                return NotFound();
            }

            var actorDetailsViewModel = ActorDetailsViewModel.FromActor(actor);

            return View(actorDetailsViewModel);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleteActorCommand = new DeleteActorCommand { Id = id };
            await this.mediator.Send(deleteActorCommand);

            return RedirectToAction(nameof(Index));
        }
    }
}
