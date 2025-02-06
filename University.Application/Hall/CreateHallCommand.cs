using MediatR;

namespace Cinema.Application.Halls;

    public class CreateHallCommand : IRequest
    {
        public string Name { get; set; }
        public int Seats { get; set; }
        public int BuildingId { get; set; }
    }
