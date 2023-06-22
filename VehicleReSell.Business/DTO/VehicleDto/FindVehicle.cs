using CrudApiTemplate.Attributes.Search;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.VehicleDto;

public class FindVehicle : IFindRequest<Vehicle>
{
    [Equal]
    public int? Id { get; set; }

    [In(nameof(Vehicle.Id))]
    public IList<int>? Ids { get; set; }
    
    [Contain]
    public string? Name { get; set; }

    [Contain]
    public string? Color { get; set; } 
    [Contain]
    public string? Manufacture { get; set; }

    public CarModel? CarModel { get; set; }

    public long? AssessPrice { get; set; }
    public long? SoldPrice { get; set; }

    public int? AssessorId { get; set; }

    public int? WareHouseId { get; set; }

    public int? VehicleOwnerId { get; set; }

    public int? Usage { get; set; }
    [Contain]
    public string? Description { get; set; } = string.Empty;


    public int? Capacity { get; set; }
}
