using MediatR;

using Cinema.Models;

namespace Cinema.Application.Buildings;

public class UpdateBuildingCommand : IRequest
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }



    public Building ToBuilding()
    {
        var building = new Building
        {
            Id = this.Id,
            Name = this.Name,
            Address = this.Address,
        };

        return building;
    }
}