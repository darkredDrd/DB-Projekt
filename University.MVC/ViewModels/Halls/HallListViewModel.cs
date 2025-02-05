using System.ComponentModel.DataAnnotations;

using Cinema.Models;

namespace Cinema.MVC.ViewModels.Halls;

public class HallListViewModel
{
    public int Id { get; set; }

    [Display(Name = "Hall Name")]
    public string Name { get; set; }

    [Display(Name = "Number of Seats")]
    public int Seats { get; set; }

    [Display(Name = "Building")]
    public string BuildingName { get; set; }

    public static HallListViewModel FromHall(Hall hall)
    {
        var hallListViewModel = new HallListViewModel
        {
            Id = hall.Id,
            Name = hall.Name,
            Seats = hall.Seats,
            BuildingName = hall.Building.Name
        };

        return hallListViewModel;
    }
}