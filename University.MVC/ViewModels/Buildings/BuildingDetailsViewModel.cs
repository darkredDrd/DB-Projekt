using System.ComponentModel.DataAnnotations;

using Cinema.Models;

namespace Cinema.MVC.ViewModels.Buildings;

public class BuildingListViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    [Display(Name = "Address")]
    public string Address { get; set; }


    public static BuildingListViewModel FromBuilding(Building building)
    {
        var buildingListViewModel = new BuildingListViewModel
        {
            Id = building.Id,
            Name = building.Name,
            Address = building.Address,
        };

        return buildingListViewModel;
    }
}