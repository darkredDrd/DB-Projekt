using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cinema.Application.Revenues;
using Cinema.Models;

namespace Cinema.MVC.ViewModels.Revenues
{
    public class RevenueCreateViewModel
    {
        public RevenueCreateViewModel()
        {
        }

        public RevenueCreateViewModel(List<Screening> screenings)
        {
            this.Screenings = screenings.Select(screening => new SelectListItem
            {
                Text = $"{screening.Movie.Title} - {screening.DateTime}",
                Value = screening.Id.ToString()
            }).ToList();
        }

        [Required]
        [Display(Name = "Screening")]
        public int ScreeningId { get; set; }

        [Required]
        [Display(Name = "Total Revenue")]
        [Range(0, double.MaxValue, ErrorMessage = "Total Revenue must be a positive number.")]
        public float TotalRevenue { get; set; }

        public List<SelectListItem> Screenings { get; set; }

        public CreateRevenueCommand ToCommand()
        {
            var createRevenueCommand = new CreateRevenueCommand
            {
                ScreeningId = this.ScreeningId,
                TotalRevenue = this.TotalRevenue
            };

            return createRevenueCommand;
        }
    }
}
