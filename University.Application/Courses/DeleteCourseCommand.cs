using MediatR;

namespace University.Application.Courses;

public record DeleteCourseCommand : IRequest
{
    public int Id { get; set; }
}