using MediatR;

using University.Models;

namespace University.Application.Courses;

public class UpdateCourseCommand : IRequest
{
    public int Id { get; set; }

    public string Topic { get; set; }

    public int NumberOfHours { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public List<Assignment> StudentAssignments{ get; set; } = new();
    public List<Assignment> TeacherAssignments { get; set; } = new();

    public Course ToCourse()
    {
        var course = new Course
        {
            Id = this.Id,
            Topic = this.Topic,
            NumberOfHours = this.NumberOfHours,
            StartDate = this.StartDate,
            EndDate = this.EndDate,
        };

        return course;
    }
}