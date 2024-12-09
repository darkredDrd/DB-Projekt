using MediatR;

using Microsoft.AspNetCore.Mvc;

using University.Application.Students;
using University.MVC.ViewModels.Students;

namespace University.MVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IMediator mediator;

        public StudentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var getStudentsQuery = new GetStudentsQuery();
            var students = await this.mediator.Send(getStudentsQuery);

            var studentListViewModels = students.Select(StudentListViewModel.FromStudent).ToList();

            return View(studentListViewModels);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getStudentQuery = new GetStudentQuery { Id = id.Value };
            var student = await this.mediator.Send(getStudentQuery);

            if (student == null)
            {
                return NotFound();
            }

            var studentDetailsViewModel = StudentDetailsViewModel.FromStudent(student);

            return View(studentDetailsViewModel);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentCreateViewModel studentCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var createStudentCommand = studentCreateViewModel.ToCreateStudentCommand();
                await mediator.Send(createStudentCommand);

                return RedirectToAction(nameof(Index));
            }
            return View(studentCreateViewModel);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getStudentQuery = new GetStudentQuery { Id = id.Value };
            var student = await this.mediator.Send(getStudentQuery);

            var studentUpdateViewModel = StudentUpdateViewModel.FromStudent(student);
            return View(studentUpdateViewModel);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentUpdateViewModel studentUpdateViewModel)
        {
            if (id != studentUpdateViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var updateStudentCommand = studentUpdateViewModel.ToUpdateStudentCommand();
                await this.mediator.Send(updateStudentCommand);
                
                return RedirectToAction(nameof(Index));
            }
            return View(studentUpdateViewModel);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getStudentQuery = new GetStudentQuery { Id = id.Value };
            var student = await this.mediator.Send(getStudentQuery);
            if (student == null)
            {
                return NotFound();
            }

            var studentDetailsViewModel = StudentDetailsViewModel.FromStudent(student);

            return View(studentDetailsViewModel);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleteStudentCommand = new DeleteStudentCommand();
            await this.mediator.Send(deleteStudentCommand);

            return RedirectToAction(nameof(Index));
        }
    }
}
