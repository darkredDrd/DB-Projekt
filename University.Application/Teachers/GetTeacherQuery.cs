using MediatR;

using University.Models;

namespace University.Application.Teachers;

public class GetTeacherQuery : IRequest<Movie>
{
    public int Id { get; set; }
}