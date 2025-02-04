using System.ComponentModel.DataAnnotations;
using Cinema.Models;

namespace Cinema.MVC.ViewModels.Revenues;

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

    public static RevenueListViewModel FromRevenue(Revenue revenue)
    {
        var revenueListViewModel = new RevenueListViewModel
        {
            Id = revenue.Id,
            TotalRevenue = revenue.TotalRevenue,
            ScreeningDate = revenue.Screening.Date,
            MovieTitle = revenue.Screening.Movie.Title,
            HallName = revenue.Screening.Hall.Name
        };

        return revenueListViewModel;
    }
}
