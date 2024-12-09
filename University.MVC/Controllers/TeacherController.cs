using MediatR;

using Microsoft.AspNetCore.Mvc;

using University.Application.Teachers;
using University.MVC.ViewModels.Teachers;

namespace University.MVC.Controllers
{
    public class TeachersController : Controller
    {
        private readonly IMediator mediator;

        public TeachersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            var getTeachersQuery = new GetTeachersQuery();
            var teachers = await this.mediator.Send(getTeachersQuery);

            var teacherListViewModels = teachers.Select(TeacherListViewModel.FromTeacher).ToList();

            return View(teacherListViewModels);
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getTeacherQuery = new GetTeacherQuery { Id = id.Value };
            var teacher = await this.mediator.Send(getTeacherQuery);

            if (teacher == null)
            {
                return NotFound();
            }

            var teacherDetailsViewModel = TeacherDetailsViewModel.FromTeacher(teacher);

            return View(teacherDetailsViewModel);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherCreateViewModel teacherCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var createTeacherCommand = teacherCreateViewModel.ToCreateTeacherCommand();
                await mediator.Send(createTeacherCommand);

                return RedirectToAction(nameof(Index));
            }
            return View(teacherCreateViewModel);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getTeacherQuery = new GetTeacherQuery { Id = id.Value };
            var teacher = await this.mediator.Send(getTeacherQuery);

            var teacherUpdateViewModel = TeacherUpdateViewModel.FromTeacher(teacher);
            return View(teacherUpdateViewModel);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TeacherUpdateViewModel teacherUpdateViewModel)
        {
            if (id != teacherUpdateViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var updateTeacherCommand = teacherUpdateViewModel.ToUpdateTeacherCommand();
                await this.mediator.Send(updateTeacherCommand);

                return RedirectToAction(nameof(Index));
            }
            return View(teacherUpdateViewModel);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getTeacherQuery = new GetTeacherQuery { Id = id.Value };
            var teacher = await this.mediator.Send(getTeacherQuery);
            if (teacher == null)
            {
                return NotFound();
            }

            var teacherDetailsViewModel = TeacherDetailsViewModel.FromTeacher(teacher);

            return View(teacherDetailsViewModel);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleteTeacherCommand = new DeleteTeacherCommand { Id = id };
            await this.mediator.Send(deleteTeacherCommand);

            return RedirectToAction(nameof(Index));
        }
    }
}
