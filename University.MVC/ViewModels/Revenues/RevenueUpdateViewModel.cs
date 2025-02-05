using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cinema.Models;
using Cinema.Application.Revenues;

namespace Cinema.MVC.ViewModels.Revenues
{
    public class RevenueUpdateViewModel
    {
        public RevenueUpdateViewModel()
        {
        }

        public RevenueUpdateViewModel(Revenue revenue, List<Screening> screenings)
        {
            this.Id = revenue.Id;
            this.TotalRevenue = revenue.TotalRevenue;
            this.ScreeningId = revenue.Screening.Id;

            this.Screenings = screenings.Select(screening => new SelectListItem
            {
                Text = $"{screening.Movie.Title} - {screening.DateTime}",
                Value = screening.Id.ToString(),
                Selected = screening.Id == this.ScreeningId
            }).ToList();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Total Revenue")]
        [Range(0, double.MaxValue, ErrorMessage = "Total Revenue must be a positive number.")]
        public float TotalRevenue { get; set; }

        [Required]
        [Display(Name = "Screening")]
        public int ScreeningId { get; set; }

        public List<SelectListItem> Screenings { get; set; }

        public UpdateRevenueCommand ToCommand()
        {
            var updateRevenueCommand = new UpdateRevenueCommand
            {
                Id = this.Id,
                ScreeningId = this.ScreeningId,
                TotalRevenue = this.TotalRevenue
            };

            return updateRevenueCommand;
        }
    }
}
