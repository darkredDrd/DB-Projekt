using MediatR;

namespace University.Application.Marks;

public class UpdateMarkCommand : IRequest
{
    public int Id { get; set; }
    public int Score { get; set; }
    public DateTime DateAwarded { get; set; }
    public int CourseId { get; set; }
    public int TeacherId { get; set; }
    public int StudentId { get; set; }
}