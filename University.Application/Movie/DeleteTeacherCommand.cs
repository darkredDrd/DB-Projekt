using MediatR;

namespace University.Application.Teachers;

public class DeleteTeacherCommand : IRequest
{
    public int Id { get; set; }
}