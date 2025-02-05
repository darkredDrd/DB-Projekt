using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cinema.Application.Screenings;
using Cinema.Models;

namespace Cinema.MVC.ViewModels.Screenings
{
    public class ScreeningCreateViewModel
    {
        public ScreeningCreateViewModel()
        {
        }

        public ScreeningCreateViewModel(List<Movie> movies)
        {
            this.Movies = movies.Select(movie => new SelectListItem
            {
                Text = $"{movie.Title}",
                Value = movie.Id.ToString()
            }).ToList();
        }

        public ScreeningCreateViewModel(List<Hall> halls)
        {
            this.Halls = halls.Select(hall => new SelectListItem
            {
                Text = $"{hall.Name}",
                Value = hall.Id.ToString()
            }).ToList();
        }

        [Required]
        [Display(Name = "Movie")]
        public int MovieId { get; set; }

        [Required]
        [Display(Name = "Hall")]
        public int HallId { get; set; }

        [Required]
        [Display(Name = "Date Time")]
        [Range(0, double.MaxValue, ErrorMessage = "Date Time must be a positive number.")]
        public DateTime DateTime { get; set; }

        public List<SelectListItem> Movies { get; set; }

        public CreateScreeningCommand ToCommand()
        {
            var createScreeningCommand = new CreateScreeningCommand
            {
                MovieID = this.MovieId,
                HallID = this.HallId,
                DateTime = this.DateTime
            };

            return createScreeningCommand;
        }
    }
}
