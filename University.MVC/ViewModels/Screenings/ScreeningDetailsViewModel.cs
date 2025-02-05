using System.ComponentModel.DataAnnotations;
using Cinema.Models;

namespace Cinema.MVC.ViewModels.Screenings;

public class ScreeningDetailsViewModel
{
    public int Id { get; set; }

    [Display(Name = "")]
    public float TotalRevenue { get; set; }

    [Display(Name = "Screening Date")]
    public DateTime ScreeningDate { get; set; }

    [Display(Name = "Movie Title")]
    public string MovieTitle { get; set; }

    [Display(Name = "Hall Name")]
    public string HallName { get; set; }

    public static ScreeningDetailsViewModel FromScreening(Screening screening)
    {
        var screeningDetailsViewModel = new ScreeningDetailsViewModel
        {
            Id = screening.Id,
            TotalRevenue = screening.TotalRevenue,
            ScreeningDate = screening.Movie.Date,
            MovieTitle = screening.Movie.Movie.Title,
            HallName = screening.Movie.Hall.Name
        };

        return screeningDetailsViewModel;
    }
}
