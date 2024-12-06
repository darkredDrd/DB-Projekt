using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc.Rendering;

using University.Models;

namespace University.MVC.Models.Marks
{
    public class MarkUpdateViewModel
    {
        public MarkUpdateViewModel()
        {
        }

        public MarkUpdateViewModel(Mark mark, List<Course> courses, List<Teacher> teachers,
            List<Student> students)
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
    }
}
