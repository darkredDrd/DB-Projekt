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
                Text = $"{movie.Movie.Title} - {movie.Date}",
                Value = movie.Id.ToString()
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
                MovieId = this.MovieId,
                HallId = this.HallId,
                DateTime = this.DateTime
            };

            return createScreeningCommand;
        }
    }
}
