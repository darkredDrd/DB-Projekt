using System.ComponentModel.DataAnnotations;

using Cinema.Application.Buildings;

namespace Cinema.MVC.ViewModels.Buildings;

public class BuildingCreateViewModel
{
    public string Name { get; set; }

    [Display(Name = "Address")]
    public string Address { get; set; }


    public CreateBuildingCommand ToCreateBuildingCommand()
    {
        var createBuildingCommand = new CreateBuildingCommand
        {
            Name = this.Name,
            Address = this.Address,

        };

        return createBuildingCommand;
    }
}