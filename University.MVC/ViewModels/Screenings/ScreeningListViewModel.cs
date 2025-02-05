using System.ComponentModel.DataAnnotations;
using Cinema.Models;

namespace Cinema.MVC.ViewModels.Screenings;

public class ScreeningListViewModel
{
    public int Id { get; set; }

    [Display(Name = "Screening Date")]
    public DateTime DateTime { get; set; }

    [Display(Name = "Movie Title")]
    public string MovieTitle { get; set; }

    [Display(Name = "Hall Name")]
    public string HallName { get; set; }

    public static ScreeningListViewModel FromScreening(Screening screening)
    {
        var screeningListViewModel = new ScreeningListViewModel
        {
            Id = screening.Id,
            DateTime = screening.DateTime,
            MovieTitle = screening.Movie.Title,
            HallName = screening.Hall.Name
        };

        return screeningListViewModel;
    }
}
