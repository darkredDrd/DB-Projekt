using MediatR;

using Microsoft.AspNetCore.Mvc;

using University.Application.Courses;
using University.Application.Marks;
using University.MVC.ViewModels.Courses;

namespace University.MVC.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IMediator mediator;

        public CoursesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var getCoursesQuery = new GetCoursesQuery();
            var courses = await mediator.Send(getCoursesQuery);

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

            var getCourseQuery = new GetCourseQuery { Id = id.Value };

            var course = await this.mediator.Send(getCourseQuery);
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
                var createCourseCommand = courseCreateViewModel.ToCreateCourseCommand();
                await this.mediator.Send(createCourseCommand);

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

            var getCourseReferencesQuery = new GetCourseReferencesQuery();
            var courseReferences = await this.mediator.Send(getCourseReferencesQuery);

            var getCourseQuery = new GetCourseQuery { Id = id.Value };
            var course = await this.mediator.Send(getCourseQuery);

            if (course == null)
            {
                return NotFound();
            }

            var courseUpdateViewModel = CourseUpdateViewModel.FromCourse(course, courseReferences.Students, courseReferences.Teachers);
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
                var updateCourseCommand = courseUpdateViewModel.ToUpdateCourseCommand();
                await this.mediator.Send(updateCourseCommand);

              
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

            var getCourseQuery = new GetCourseQuery { Id = id.Value };

            var course = await this.mediator.Send(getCourseQuery);
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
            var deleteCourseCommand = new DeleteCourseCommand { Id = id };
            await this.mediator.Send(deleteCourseCommand);

            return RedirectToAction(nameof(Index));
        }
    }
}
