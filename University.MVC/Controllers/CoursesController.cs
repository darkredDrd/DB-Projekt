using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using University.Persistence;

using University.MVC.Models.Courses;

namespace University.MVC.Controllers
{
    public class CoursesController : Controller
    {
        private readonly UniversityContext context;

        public CoursesController(UniversityContext context)
        {
            this.context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var courses = await context.Courses.ToListAsync();

            var courseListViewModels = courses.Select(CourseListViewModel.FromCourse).ToList();

            return View(courseListViewModels);
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            var courseDetailsViewModel = CourseDetailsViewModel.FromCourse(course);

            return View(courseDetailsViewModel);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseCreateViewModel courseCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var course = courseCreateViewModel.ToCourse();

                context.Add(course);
                await context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(courseCreateViewModel);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            var courseUpdateViewModel = CourseUpdateViewModel.FromCourse(course);
            return View(courseUpdateViewModel);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CourseUpdateViewModel courseUpdateViewModel)
        {
            if (id != courseUpdateViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var course = courseUpdateViewModel.ToCourse();
                try
                {
                    context.Update(course);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
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
            return View(courseUpdateViewModel);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            var courseDetailsViewModel = CourseDetailsViewModel.FromCourse(course);

            return View(courseDetailsViewModel);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await context.Courses.FindAsync(id);
            if (course != null)
            {
                context.Courses.Remove(course);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return context.Courses.Any(e => e.Id == id);
        }
    }
}
