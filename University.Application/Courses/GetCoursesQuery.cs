using MediatR;

using University.Models;

namespace University.Application.Courses;

public class GetCoursesQuery : IRequest<List<Course>>
{

}