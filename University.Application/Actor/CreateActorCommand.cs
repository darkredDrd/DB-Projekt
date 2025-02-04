using MediatR;
using Cinema.Models;

namespace Cinema.Application.Actors;

public class CreateActorCommand : IRequest
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public Actor ToActor()
    {
        var actor = new Actor
        {
            FirstName = this.FirstName,
            LastName = this.LastName,
            BirthDate = this.BirthDate,
        };

        return actor;
    }
}
