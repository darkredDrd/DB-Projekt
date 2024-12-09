using MediatR;

using University.Models;

namespace University.Application.Courses;

public class GetCourseQuery : IRequest<Course>
{
    public int Id;
}