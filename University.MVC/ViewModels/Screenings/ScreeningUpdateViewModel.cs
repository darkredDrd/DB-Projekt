using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cinema.Models;
using Cinema.Application.Screenings;

namespace Cinema.MVC.ViewModels.Screenings
{
    public class ScreeningUpdateViewModel
    {
        public ScreeningUpdateViewModel()
        {
        }

        public ScreeningUpdateViewModel(Screening screening, List<Movie> movies)
        {
            this.Id = screening.Id;
            this.Hall = screening.Hall;
            this.ScreeningId = screening.Movie.Id;

            this.Movies = movies.Select(movie => new SelectListItem
            {
                Text = $"{movie.Movie.Title} - {movie.Date}",
                Value = movie.Id.ToString(),
                Selected = movie.Id == this.MovieId
            }).ToList();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date Time")]
        [Range(typeof(DateTime), "1/1/2000", "12/31/2099", ErrorMessage = "Date Time must be between 01/01/2000 and 12/31/2099.")]
        public DateTime DateTime { get; set; }

        [Required]
        [Display(Name = "Movie")]
        public int MovieId { get; set; }

        [Required]
        [Display(Name = "Hall")]
        public int HallId { get; set; }

        public List<SelectListItem> Movies { get; set; }

        public UpdateScreeningCommand ToCommand()
        {
            var updateScreeningCommand = new UpdateScreeningCommand
            {
                Id = this.Id,
                MovieId = this.MovieId,
                HallId = this.HallId,
                DateTime = this.DateTime
            };

            return updateScreeningCommand;
        }
    }
}
