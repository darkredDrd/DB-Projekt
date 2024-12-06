using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using University.Persistence;

using University.MVC.Models.Teachers;

namespace University.MVC.Controllers
{
    public class TeachersController : Controller
    {
        private readonly UniversityContext context;

        public TeachersController(UniversityContext context)
        {
            this.context = context;
        }

        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            var teachers = await context.Teachers.ToListAsync();

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

            var teacher = await context.Teachers
                .FirstOrDefaultAsync(m => m.Id == id);
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
                var teacher = teacherCreateViewModel.ToTeacher();

                context.Add(teacher);
                await context.SaveChangesAsync();

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

            var teacher = await context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

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
                var teacher = teacherUpdateViewModel.ToTeacher();
                try
                {
                    context.Update(teacher);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.Id))
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
            return View(teacherUpdateViewModel);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await context.Teachers
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var teacher = await context.Teachers.FindAsync(id);
            if (teacher != null)
            {
                context.Teachers.Remove(teacher);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
            return context.Teachers.Any(e => e.Id == id);
        }
    }
}
