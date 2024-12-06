using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc.Rendering;

using University.Application.Marks;
using University.Models;

namespace University.MVC.ViewModels.Marks
{
    public class MarkCreateViewModel
    {
        public MarkCreateViewModel()
        {
        }

        public MarkCreateViewModel(List<Course> courses, List<Teacher> teachers, List<Student> students)
        {
            this.Courses = courses.Select(course => new SelectListItem
            {
                Text = course.Topic,
                Value = course.Id.ToString()
            }).ToList();

            this.Teachers = teachers.Select(teacher => new SelectListItem
            {
                Text = $"{teacher.FirstName} {teacher.LastName}",
                Value = teacher.Id.ToString()
            }).ToList();

            this.Students = students.Select(student => new SelectListItem
            {
                Text = $"{student.FirstName} {student.LastName}",
                Value = student.Id.ToString()
            }).ToList();
        }

        [Required]
        [Range(0, 100)]
        public int Score { get; set; }

        [Required]
        [Display(Name = "Date Awarded")]
        public DateTime DateAwarded { get; set; }

        public List<SelectListItem> Courses { get; set; }

        [Required]
        public int CourseId { get; set; }

        public List<SelectListItem> Teachers { get; set; }

        [Required]
        public int TeacherId { get; set; }

        public List<SelectListItem> Students { get; set; }

        [Required]
        public int StudentId { get; set; }

        public CreateMarkCommand ToCommand()
        {
            var createMarkCommand = new CreateMarkCommand
            {
                CourseId = this.CourseId,
                DateAwarded = this.DateAwarded,
                Score = this.Score,
                StudentId = this.StudentId,
                TeacherId = this.TeacherId
            };

            return createMarkCommand;
        }
    }
}
