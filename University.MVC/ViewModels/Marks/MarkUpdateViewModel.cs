using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc.Rendering;

using University.Application.Marks;
using University.Models;

namespace University.MVC.ViewModels.Marks
{
    public class RevenueUpdateViewModel
    {
        public RevenueUpdateViewModel()
        {
        }

        public RevenueUpdateViewModel(Hall mark, List<Cinema> courses, List<Movie> teachers,
            List<Revenue> students)
        {
            this.Score = mark.Score;
            this.DateAwarded = mark.DateAwarded;
            this.CourseId = mark.Course.Id;
            this.TeacherId = mark.Teacher.Id;
            this.StudentId = mark.Student.Id;

            this.Courses = courses.Select(course => new SelectListItem
            {
                Text = course.Topic,
                Value = course.Id.ToString(),
                Selected = course.Id == this.CourseId
            }).ToList();

            this.Teachers = teachers.Select(teacher => new SelectListItem
            {
                Text = $"{teacher.FirstName} {teacher.LastName}",
                Value = teacher.Id.ToString(),
                Selected = teacher.Id == this.TeacherId
            }).ToList();

            this.Students = students.Select(student => new SelectListItem
            {
                Text = $"{student.FirstName} {student.LastName}",
                Value = student.Id.ToString(),
                Selected = student.Id == this.StudentId
            }).ToList();
        }

        [Required]
        public int Id { get; set; }

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

        public UpdateMarkCommand ToCommand()
        {
            var updateMarkCommand = new UpdateMarkCommand
            {
                Id = this.Id,
                CourseId = this.CourseId,
                DateAwarded = this.DateAwarded,
                Score = this.Score,
                StudentId = this.StudentId,
                TeacherId = this.TeacherId
            };

            return updateMarkCommand;
        }
    }
}
