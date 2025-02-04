using System.ComponentModel.DataAnnotations;

using Cinema.Models;

namespace Cinema.MVC.ViewModels.Buildings;

public class BuildingDetailsViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    [Display(Name = "Address")]
    public string Address { get; set; }


    public static BuildingDetailsViewModel FromCourse(Building building)
    {
        var buildingDetailsViewModel = new BuildingDetailsViewModel
        {
            Id = building.Id,
            Name = building.Name,
            Address = building.Address,
        };

        return buildingDetailsViewModel;
    }
}