using MediatR;

namespace University.Application.Marks;

public class DeleteMarkCommand : IRequest
{
    public int Id { get; set; }
}