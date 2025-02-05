using System.ComponentModel.DataAnnotations;
using Cinema.Models;

namespace Cinema.MVC.ViewModels.Screenings;

public class RevenueListViewModel
{
    public int Id { get; set; }

    [Display(Name = "Total Revenue")]
    public float TotalRevenue { get; set; }

    [Display(Name = "Screening Date")]
    public DateTime ScreeningDate { get; set; }

    [Display(Name = "Movie Title")]
    public string MovieTitle { get; set; }

    [Display(Name = "Hall Name")]
    public string HallName { get; set; }

    public static ScreeningListViewModel FromScreening(Screening screening)
    {
        var screeningListViewModel = new ScreeningListViewModel
        {
            Id = screening.Id,
            TotalRevenue = screening.TotalRevenue,
            ScreeningDate = screening.Movie.Date,
            MovieTitle = screening.Movie.Movie.Title,
            HallName = screening.Movie.Hall.Name
        };

        return screeningListViewModel;
    }
}
