using MediatR;

using University.Models;

namespace University.Application.Teachers;

public class GetTeacherQuery : IRequest<Teacher>
{
    public int Id { get; set; }
}