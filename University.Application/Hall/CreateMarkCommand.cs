using MediatR;

namespace Cinema.Application.Marks
{
    public class CreateMarkCommand : IRequest
    {
        public string Name { get; set; }
        public int Seats { get; set; }
        public int CinemaId { get; set; }
    }
}
