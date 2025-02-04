using MediatR;

using Microsoft.AspNetCore.Mvc;

using University.Application.Marks;
using University.MVC.ViewModels.Marks;

namespace University.MVC.Controllers
{
    public class MarksController : Controller
    {
        private readonly IMediator mediator;

        public MarksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: MarksController
        public async Task<ActionResult> Index()
        {
            var getMarksListQuery = new GetMarksListQuery();
            var marks = await mediator.Send(getMarksListQuery);

            var markListViewModels = marks.Select(RevenueListViewModel.FromMark);

            return View(markListViewModels);
        }

        // GET: MarksController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var getMarkQuery = new GetMarkQuery { Id = id };
            var mark = await mediator.Send(getMarkQuery);

            var markDetailsViewModel = RevenueDetailsViewModel.FromMark(mark);

            return View(markDetailsViewModel);
        }

        // GET: MarksController/Create
        public async Task<ActionResult> Create()
        {
            var getMarkReferencesQuery = new GetMarkReferencesQuery();
            var markReferences = await this.mediator.Send(getMarkReferencesQuery);

            var markCreateViewModel = new MarkCreateViewModel(markReferences.Courses, markReferences.Teachers, markReferences.Students);

            return View(markCreateViewModel);
        }

        // POST: MarksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RevenueCreateViewModel markCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var createMarkCommand = markCreateViewModel.ToCommand();
                
                await mediator.Send(createMarkCommand);

                return RedirectToAction(nameof(Index));
            }

            return View(markCreateViewModel);
        }

        // GET: MarksController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var getMarkReferencesQuery = new GetMarkReferencesQuery();
            var markReferences = await this.mediator.Send(getMarkReferencesQuery);

            var getMarkQuery = new GetMarkQuery { Id = id };
            var mark = await mediator.Send(getMarkQuery);

            var markUpdateViewModel = new MarkUpdateViewModel(mark, markReferences.Courses, markReferences.Teachers, markReferences.Students);

            return View(markUpdateViewModel);
        }

        // POST: MarksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, RevenueUpdateViewModel markUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                var updateMarkCommand = markUpdateViewModel.ToCommand();

                await mediator.Send(updateMarkCommand);

                return RedirectToAction(nameof(Index));
            }

            return View(markUpdateViewModel);
        }

        // GET: MarksController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var getMarkQuery = new GetMarkQuery { Id = id };
            var mark = await mediator.Send(getMarkQuery);

            var markDetailsViewModel = RevenueDetailsViewModel.FromMark(mark);

            return View(markDetailsViewModel);
        }

        // POST: MarksController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleteMarkCommand = new DeleteMarkCommand { Id = id };

            await mediator.Send(deleteMarkCommand);
            
            return RedirectToAction(nameof(Index));
        }
    }
}