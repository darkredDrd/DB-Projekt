using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc.Rendering;

using Cinema.Application.Hall;
using Cinema.Models;

namespace Cinema.MVC.ViewModels.Halls
{
    public class HallCreateViewModel
    {
        public HallCreateViewModel()
        {
        }

        public HallCreateViewModel(List<Building> buildings)
        {
            this.Buildings = buildings.Select(building => new SelectListItem
            {
                Text = building.Name,
                Value = building.Id.ToString()
            }).ToList();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(1, 500)]
        public int Seats { get; set; }

        public List<SelectListItem> Buildings { get; set; }

        [Required]
        public int BuildingId { get; set; }

        public CreateHallCommand ToCommand()
        {
            var createHallCommand = new CreateHallCommand
            {
                Name = this.Name,
                Seats = this.Seats,
                BuildingId = this.BuildingId
            };

            return createHallCommand;
        }
    }
}