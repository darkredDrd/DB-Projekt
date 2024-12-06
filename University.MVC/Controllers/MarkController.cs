using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using University.Models;
using University.MVC.Models.Marks;
using University.MVC.Models.Students;
using University.Persistence;

namespace University.MVC.Controllers
{
    public class MarkController : Controller
    {
        private readonly UniversityContext context;

        public MarkController(UniversityContext context)
        {
            this.context = context;
        }
        // GET: MarkController
        public async Task<ActionResult> Index()
        {
            var marks = await context.Mark
                .Include(mark => mark.Course)
                .Include(mark => mark.Teacher)
                .Include(mark => mark.Student)
                .ToListAsync();

            var markListViewModels = marks.Select(MarkListViewModel.FromMark);

            return View(markListViewModels);
        }

        // GET: MarkController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MarkController/Create
        public async Task<ActionResult> Create()
        {
            var allCourses = await context.Courses.ToListAsync();
            var allStudents = await context.Students.ToListAsync();
            var allTeachers = await context.Teachers.ToListAsync();

            var markCreateViewModel = new MarkCreateViewModel(allCourses, allTeachers, allStudents);

            return View(markCreateViewModel);
        }

        // POST: MarkController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MarkCreateViewModel markCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var course = await context.Courses.FirstOrDefaultAsync(m => m.Id == markCreateViewModel.CourseId);
                if (course == null)
                {
                    return NotFound();
                }

                var teacher = await context.Teachers.FirstOrDefaultAsync(m => m.Id == markCreateViewModel.TeacherId);
                if (teacher == null)
                {
                    return NotFound();
                }

                var student = await context.Students.FirstOrDefaultAsync(m => m.Id == markCreateViewModel.StudentId);
                if (student == null)
                {
                    return NotFound();
                }

                var mark = new Mark
                {
                    Score = markCreateViewModel.Score,
                    DateAwarded = markCreateViewModel.DateAwarded,
                    Course = course,
                    Teacher = teacher,
                    Student = student
                };

                context.Add(mark);
                await context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(markCreateViewModel);
        }

        // GET: MarkController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var allCourses = await context.Courses.ToListAsync();
            var allStudents = await context.Students.ToListAsync();
            var allTeachers = await context.Teachers.ToListAsync();

            var mark = await context.Mark
                .Include(mark => mark.Course)
                .Include(mark => mark.Teacher)
                .Include(mark => mark.Student)
                .FirstOrDefaultAsync(mark => mark.Id == id);

            var markUpdateViewModel = new MarkUpdateViewModel(mark, allCourses, allTeachers, allStudents);

            return View(markUpdateViewModel);
        }

        // POST: MarkController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MarkUpdateViewModel markUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                var existingMark = await context.Mark
                    .Include(mark => mark.Course)
                    .Include(mark => mark.Teacher)
                    .Include(mark => mark.Student)
                    .FirstOrDefaultAsync(mark => mark.Id == id);

                var course = await context.Courses.FirstOrDefaultAsync(m => m.Id == markUpdateViewModel.CourseId);
                if (course == null)
                {
                    return NotFound();
                }

                var teacher = await context.Teachers.FirstOrDefaultAsync(m => m.Id == markUpdateViewModel.TeacherId);
                if (teacher == null)
                {
                    return NotFound();
                }

                var student = await context.Students.FirstOrDefaultAsync(m => m.Id == markUpdateViewModel.StudentId);
                if (student == null)
                {
                    return NotFound();
                }

                existingMark.Score = markUpdateViewModel.Score;
                existingMark.DateAwarded = markUpdateViewModel.DateAwarded;
                existingMark.Course = course;
                existingMark.Teacher = teacher;
                existingMark.Student = student;

                await context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(markUpdateViewModel);
        }

        // GET: MarkController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MarkController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
