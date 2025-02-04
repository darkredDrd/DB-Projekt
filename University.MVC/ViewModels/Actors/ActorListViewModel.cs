using System.ComponentModel.DataAnnotations;

using Cinema.Models;

namespace Cinema.MVC.ViewModels.Actors;

public class ActorListViewModel
{
    public int Id { get; set; }

    [Display(Name = "Full name")]
    public string FullName { get; set; }

    public DateTime BirthDate { get; set; }


    public static ActorListViewModel FromActor(Actor actor)
    {
        var actorListViewModel = new ActorListViewModel
        {
            Id = actor.Id,
            FullName = $"{actor.FirstName} {actor.LastName}",
            BirthDate = actor.BirthDate
        };

        return actorListViewModel;
    }
}