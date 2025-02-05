using Cinema.Application.Buildings;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Cinema.MVC.ViewModels.Buildings;

namespace Cinema.MVC.Controllers
{
    public class BuildingsController : Controller
    {
        private readonly IMediator mediator;

        public BuildingsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: Buildings
        public async Task<IActionResult> Index()
        {
            var getBuildingsQuery = new GetBuildingsQuery();
            var buildings = await mediator.Send(getBuildingsQuery);

            var buildingDetailsViewModels = buildings.Select(BuildingDetailsViewModel.FromBuilding).ToList();

            return View(buildingDetailsViewModels);
        }

        // GET: Buildings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getBuildingQuery = new GetBuildingQuery { Id = id.Value };

            var building = await this.mediator.Send(getBuildingQuery);
            if (building == null)
            {
                return NotFound();
            }

            var buildingDetailsViewModel = BuildingDetailsViewModel.FromBuilding(building);

            return View(buildingDetailsViewModel);
        }

        // GET: Buildings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buildings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BuildingCreateViewModel buildingCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var createBuildingCommand = buildingCreateViewModel.ToCreateBuildingCommand();
                await this.mediator.Send(createBuildingCommand);

                return RedirectToAction(nameof(Index));
            }
            return View(buildingCreateViewModel);
        }

        // GET: Buildings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getBuildingReferencesQuery = new GetBuildingReferencesQuery();
            var buildingReferences = await this.mediator.Send(getBuildingReferencesQuery);

            var getBuildingQuery = new GetBuildingQuery { Id = id.Value };
            var building = await this.mediator.Send(getBuildingQuery);

            if (building == null)
            {
                return NotFound();
            }

            var buildingUpdateViewModel = BuildingUpdateViewModel.FromBuilding(building, buildingReferences.Students, buildingReferences.Teachers);
            return View(buildingUpdateViewModel);
        }

        // POST: Buildings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BuildingUpdateViewModel buildingUpdateViewModel)
        {
            if (id != buildingUpdateViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var updateBuildingCommand = buildingUpdateViewModel.ToUpdateBuildingCommand();
                await this.mediator.Send(updateBuildingCommand);

              
                return RedirectToAction(nameof(Index));
            }
            return View(buildingUpdateViewModel);
        }

        // GET: Buildings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getBuildingQuery = new GetBuildingQuery { Id = id.Value };

            var building = await this.mediator.Send(getBuildingQuery);
            if (building == null)
            {
                return NotFound();
            }

            var buildingDetailsViewModel = BuildingDetailsViewModel.FromBuilding(building);

            return View(buildingDetailsViewModel);
        }

        // POST: Buildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleteBuildingCommand = new DeleteBuildingCommand { Id = id };
            await this.mediator.Send(deleteBuildingCommand);

            return RedirectToAction(nameof(Index));
        }
    }
}
