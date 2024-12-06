using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using University.MVC.ViewModels.Students;
using University.Persistence;

namespace University.MVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly UniversityContext context;

        public StudentsController(UniversityContext context)
        {
            this.context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var students = await context.Students.ToListAsync();

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

            var student = await context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
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
                var student = studentCreateViewModel.ToStudent();

                context.Add(student);
                await context.SaveChangesAsync();

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

            var student = await context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

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
                var student = studentUpdateViewModel.ToStudent();
                try
                {
                    context.Update(student);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
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

            var student = await context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var student = await context.Students.FindAsync(id);
            if (student != null)
            {
                context.Students.Remove(student);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return context.Students.Any(e => e.Id == id);
        }
    }
}
