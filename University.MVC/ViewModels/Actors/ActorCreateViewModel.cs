using System.ComponentModel.DataAnnotations;
using Cinema.Application.Actor;
using Cinema.Application.Actors;

namespace Cinema.MVC.ViewModels.Actors
{
    public class ActorCreateViewModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public CreateActorCommand ToCreateActorCommand()
        {
            var createActorCommand = new CreateActorCommand
            {
               
                FirstName = this.FirstName,
                LastName = this.LastName,

                BirthDate = this.BirthDate,
            };

            return createActorCommand;
        }
    }
}
