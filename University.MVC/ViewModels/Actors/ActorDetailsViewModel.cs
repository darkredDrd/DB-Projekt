using System.ComponentModel.DataAnnotations;

using Cinema.Models;

namespace Cinema.MVC.ViewModels.Actors;

public class ActorDetailsViewModel
{
    public int Id { get; set; }

    [Display(Name = "First name")]
    public string FirstName { get; set; }

    [Display(Name = "Last name")]
    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public static ActorDetailsViewModel FromActor(Actor actor)
    {
        var actortDetailsViewModel = new ActorDetailsViewModel()
        {
            Id = actor.Id,
            FirstName = actor.FirstName,
            LastName = actor.LastName,
            BirthDate = actor.BirthDate
        };

        return actorDetailsViewModel;
    }
}