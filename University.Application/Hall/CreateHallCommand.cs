using MediatR;

namespace Cinema.Application.Hall;
{
    public class CreateHallCommand : IRequest
    {
        public string Name { get; set; }
        public int Seats { get; set; }
        public int CinemaId { get; set; }
    }
}
