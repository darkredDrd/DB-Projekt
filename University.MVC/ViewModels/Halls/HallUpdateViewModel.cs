using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc.Rendering;

using Cinema.Application.Hall;
using Cinema.Models;

namespace Cinema.MVC.ViewModels.Halls
{
    public class HallUpdateViewModel
    {
        public HallUpdateViewModel()
        {
        }

        public HallUpdateViewModel(Hall hall, List<Building> buildings)
        {
            this.Id = hall.Id;
            this.Name = hall.Name;
            this.Seats = hall.Seats;
            this.BuildingId = hall.Building.Id;

            this.Buildings = buildings.Select(building => new SelectListItem
            {
                Text = building.Name,
                Value = building.Id.ToString(),
                Selected = building.Id == this.BuildingId
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

        public List<SelectListItem> Buildings { get; set; }

        [Required]
        public int BuildingId { get; set; }

        public UpdateHallCommand ToCommand()
        {
            var updateHallCommand = new UpdateHallCommand
            {
                Id = this.Id,
                Name = this.Name,
                Seats = this.Seats,
                BuildingId = this.BuildingId
            };

            return updateHallCommand;
        }
    }
}