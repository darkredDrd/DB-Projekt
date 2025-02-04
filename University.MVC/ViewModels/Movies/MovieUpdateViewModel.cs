using System.ComponentModel.DataAnnotations;
using Cinema.Application.Movies;
using Cinema.Models;

namespace Cinema.MVC.ViewModels.Movies;

public class MovieUpdateViewModel
{
    [Required]
    public int Id { get; set; }

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

    public UpdateMovieCommand ToUpdateMovieCommand()
    {
        var updateMovieCommand = new UpdateMovieCommand
        {
            Id = this.Id,
            Title = this.Title,
            Genre = this.Genre,
            DurationMinutes = this.DurationMinutes
        };

        return updateMovieCommand;
    }

    public static MovieUpdateViewModel FromMovie(Movie movie)
    {
        var movieUpdateViewModel = new MovieUpdateViewModel
        {
            Id = movie.Id,
            Title = movie.Title,
            Genre = movie.Genre,
            DurationMinutes = movie.DurationMinutes
        };

        return movieUpdateViewModel;
    }
}