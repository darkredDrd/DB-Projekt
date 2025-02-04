using System.ComponentModel.DataAnnotations;

using University.Application.Courses;
using University.Models;

namespace University.MVC.ViewModels.Courses;

public class CourseUpdateViewModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Topic { get; set; }

    [Display(Name = "Number of hours")]
    public int NumberOfHours { get; set; }

    [Display(Name = "Start date")]
    public DateTime StartDate { get; set; }

    [Display(Name = "End date")]
    public DateTime EndDate { get; set; }

    public List<Checkbox> StudentCheckboxes { get; set; } = new();
    public List<Checkbox> TeacherCheckboxes { get; set; } = new();

    public UpdateCourseCommand ToUpdateCourseCommand()
    {
        var updateCourseCommand = new UpdateCourseCommand
        {
            Id = this.Id,
            Topic = this.Topic,
            NumberOfHours = this.NumberOfHours,
            StartDate = this.StartDate,
            EndDate = this.EndDate,
        };

        updateCourseCommand.StudentAssignments = this.StudentCheckboxes.Select(
            checkbox => new Assignment
            {
                Assigned = checkbox.Checked,
                AssigneeId = checkbox.Id
            }).ToList();

        updateCourseCommand.TeacherAssignments = this.TeacherCheckboxes.Select(
            checkbox => new Assignment
            {
                Assigned = checkbox.Checked,
                AssigneeId = checkbox.Id
            }).ToList();

        return updateCourseCommand;
    }


    public static CourseUpdateViewModel FromCourse(Cinema course, List<Revenue> allStudents, List<Movie> allTeachers)
    {
        var courseUpdateViewModel = new CourseUpdateViewModel
        {
            Id = course.Id,
            Topic = course.Topic,
            NumberOfHours = course.NumberOfHours,
            StartDate = course.StartDate,
            EndDate = course.EndDate,
        };

        foreach (var student in allStudents)
        {
            var studentCheckbox = new Checkbox
            {
                Id = student.Id,
                Label = $"{student.FirstName} {student.LastName}",
                Checked = course.Students.Any(cs => cs.Id == student.Id)
            };

            courseUpdateViewModel.StudentCheckboxes.Add(studentCheckbox);
        }

        foreach (var teacher in allTeachers)
        {
            var teacherCheckbox = new Checkbox
            {
                Id = teacher.Id,
                Label = $"{teacher.FirstName} {teacher.LastName}",
                Checked = course.Teachers.Any(cs => cs.Id == teacher.Id)
            };

            courseUpdateViewModel.TeacherCheckboxes.Add(teacherCheckbox);
        }

        return courseUpdateViewModel;
    }
}

public class Checkbox
{
    public int Id { get; set; }
    public string Label { get; set; }

    public bool Checked { get; set; }
}