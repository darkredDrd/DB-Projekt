using MediatR;

using University.Models;

namespace University.Application.Courses;

public class CreateCourseCommand : IRequest
{
    public string Topic { get; set; }

    public int NumberOfHours { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public Course ToCourse()
    {
        var course = new Course
        {
            Topic = this.Topic,
            NumberOfHours = this.NumberOfHours,
            StartDate = this.StartDate,
            EndDate = this.EndDate,
        };

        return course;
    }
}