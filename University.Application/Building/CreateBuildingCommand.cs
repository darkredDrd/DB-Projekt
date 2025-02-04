using MediatR;

using Cinema.Models;

namespace Cinema.Application.Buildings;

public class CreateBuildingCommand : IRequest
{
    public string Name { get; set; }

    public string Address { get; set; }

    public Building ToBuilding()
    {
        var building = new Building
        {
            Name = this.Name,
            Address = this.Address,
        };

        return building;
    }
}