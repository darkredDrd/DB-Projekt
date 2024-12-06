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

            var allStudents = await context.Students.ToListAsync();
            var allTeachers = await context.Teachers.ToListAsync();


            var course = await context.Courses
                .Include(course => course.Students)
                .Include(course => course.Teachers)
                .FirstOrDefaultAsync(course => course.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            var courseUpdateViewModel = CourseUpdateViewModel.FromCourse(course, allStudents, allTeachers);
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
                try
                {
                    var existingCourse = await context.Courses
                        .Include(course => course.Students).Include(course => course.Teachers)
                        .FirstOrDefaultAsync(course => course.Id == id);

                    existingCourse.Topic = courseUpdateViewModel.Topic;
                    existingCourse.NumberOfHours = courseUpdateViewModel.NumberOfHours;
                    existingCourse.StartDate = courseUpdateViewModel.StartDate;
                    existingCourse.EndDate = courseUpdateViewModel.EndDate;

                    foreach (var studentCheckbox in courseUpdateViewModel.StudentCheckboxes)
                    {
                        var existingStudentInACourse = existingCourse.Students.FirstOrDefault(student => student.Id == studentCheckbox.Id);

                        if (existingStudentInACourse == null && studentCheckbox.Checked)
                        {
                            // Add a student to a course
                            var newStudent = await context.Students.FirstOrDefaultAsync(m => m.Id == studentCheckbox.Id);
                            existingCourse.Students.Add(newStudent);
                        }

                        if (existingStudentInACourse != null && !studentCheckbox.Checked)
                        {
                            // Remove a student from a course
                            existingCourse.Students.Remove(existingStudentInACourse);
                        }
                    }

                    foreach (var teacherCheckbox in courseUpdateViewModel.TeacherCheckboxes)
                    {
                        var existingTeacherInACourse = existingCourse.Teachers.FirstOrDefault(teacher => teacher.Id == teacherCheckbox.Id);

                        if (existingTeacherInACourse == null && teacherCheckbox.Checked)
                        {
                            // Add a teacher to a course
                            var newTeacher = await context.Teachers.FirstOrDefaultAsync(m => m.Id == teacherCheckbox.Id);
                            existingCourse.Teachers.Add(newTeacher);
                        }

                        if (existingTeacherInACourse != null && !teacherCheckbox.Checked)
                        {
                            // Remove a teacher from a course
                            existingCourse.Teachers.Remove(existingTeacherInACourse);
                        }
                    }

                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(id))
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
