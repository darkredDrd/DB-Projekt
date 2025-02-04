using System.ComponentModel.DataAnnotations;
using Cinema.Application.Movies;

namespace Cinema.MVC.ViewModels.Movies
{
    public class MovieCreateViewModel
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Genre")]
        public string Genre { get; set; }

        [Required]
        [Display(Name = "Duration (minutes)")]
        public int DurationMinutes { get; set; }

        public CreateMovieCommand ToCreateMovieCommand()
        {
            var createMovieCommand = new CreateMovieCommand
            {
                Title = this.Title,
                Genre = this.Genre,
                DurationMinutes = this.DurationMinutes
            };

            return createMovieCommand;
        }
    }
}