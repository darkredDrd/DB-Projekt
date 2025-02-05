using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc.Rendering;

using Cinema.Application.Marks;
using Cinema.Models;

namespace Cinema.MVC.ViewModels.Halls
{
    public class HallCreateViewModel
    {
        public HallCreateViewModel()
        {
        }

        public HallCreateViewModel(List<Cinema> cinemas)
        {
            this.Cinemas = cinemas.Select(cinema => new SelectListItem
            {
                Text = cinema.Name,
                Value = cinema.Id.ToString()
            }).ToList();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(1, 500)]
        public int Seats { get; set; }

        public List<SelectListItem> Cinemas { get; set; }

        [Required]
        public int CinemaId { get; set; }

        public CreateMarkCommand ToCommand()
        {
            var createMarkCommand = new CreateMarkCommand
            {
                Name = this.Name,
                Seats = this.Seats,
                CinemaId = this.CinemaId
            };

            return createMarkCommand;
        }
    }
}