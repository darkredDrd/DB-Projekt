using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc.Rendering;

using Cinema.Application.Marks;
using Cinema.Models;

namespace Cinema.MVC.ViewModels.Halls
{
    public class HallUpdateViewModel
    {
        public HallUpdateViewModel()
        {
        }

        public HallUpdateViewModel(Hall hall, List<Cinema> cinemas)
        {
            this.Id = hall.Id;
            this.Name = hall.Name;
            this.Seats = hall.Seats;
            this.CinemaId = hall.Cinema.Id;

            this.Cinemas = cinemas.Select(cinema => new SelectListItem
            {
                Text = cinema.Name,
                Value = cinema.Id.ToString(),
                Selected = cinema.Id == this.CinemaId
            }).ToList();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(1, 500)]
        public int Seats { get; set; }

        public List<SelectListItem> Cinemas { get; set; }

        [Required]
        public int CinemaId { get; set; }

        public UpdateMarkCommand ToCommand()
        {
            var updateMarkCommand = new UpdateMarkCommand
            {
                Id = this.Id,
                Name = this.Name,
                Seats = this.Seats,
                CinemaId = this.CinemaId
            };

            return updateMarkCommand;
        }
    }
}