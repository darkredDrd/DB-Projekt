using System.ComponentModel.DataAnnotations;
using Cinema.Application.Actor;
using Cinema.Application.Actors;
using Cinema.Models;

namespace Cinema.MVC.ViewModels.Actors;

public class ActorUpdateViewModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    [Display(Name = "First name")]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(100)]
    [Display(Name = "Last name")]
    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public UpdateActorCommand ToUpdateActorCommand()
    {
        var updateActorCommand = new UpdateActorCommand
        {
            Id = this.Id,
            FirstName = this.FirstName,
            LastName = this.LastName,
            BirthDate = this.BirthDate
        };

        return updateActorCommand;
    }

    public static ActorUpdateViewModel FromActor(Actor actor)
    {
        var actorUpdateViewModel = new ActorUpdateViewModel
        {
            Id = actor.Id,
            FirstName = actor.FirstName,
            LastName = actor.LastName,
            BirthDate = actor.BirthDate
        };

        return actorUpdateViewModel;
    }
}