using MediatR;

namespace University.Application.Marks
{
    public class CreateMarkCommand : IRequest
    {
        public int Score { get; set; }
        public DateTime DateAwarded { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
    }
}
