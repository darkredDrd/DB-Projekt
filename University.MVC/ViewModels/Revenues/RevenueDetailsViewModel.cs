using System.ComponentModel.DataAnnotations;
using Cinema.Models;

namespace Cinema.MVC.ViewModels.Revenues;

public class RevenueDetailsViewModel
{
    public int Id { get; set; }

    [Display(Name = "Total Revenue")]
    public float TotalRevenue { get; set; }

    [Display(Name = "Screening Date")]
    public DateTime ScreeningDateTime { get; set; }

    [Display(Name = "Movie Title")]
    public string MovieTitle { get; set; }

    [Display(Name = "Hall Name")]
    public string HallName { get; set; }

    public static RevenueDetailsViewModel FromRevenue(Revenue revenue)
    {
        var revenueDetailsViewModel = new RevenueDetailsViewModel
        {
            Id = revenue.Id,
            TotalRevenue = revenue.TotalRevenue,
            ScreeningDateTime = revenue.Screening.DateTime,
            MovieTitle = revenue.Screening.Movie.Title,
            HallName = revenue.Screening.Hall.Name
        };

        return revenueDetailsViewModel;
    }
}
