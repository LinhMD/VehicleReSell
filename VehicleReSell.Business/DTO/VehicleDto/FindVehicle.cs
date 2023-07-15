using CrudApiTemplate.Attributes.Search;
using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.VehicleDto;

public class FindVehicle : IFindRequest<Vehicle>
{

    [Equal(target:"VehicleOwner.Phone")]
    public string? OwnerPhone { get; set; }
    
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

    [BiggerThan(nameof(Vehicle.SoldPrice))]
    public long? SoldPriceLow { get; set; }
    
    [LessThan(nameof(Vehicle.SoldPrice))]
    public long? SoldPriceHigh { get; set; }
    
    public int? AssessorId { get; set; }

    public int? WareHouseId { get; set; }

    public int? VehicleOwnerId { get; set; }

    public int? Usage { get; set; }
    [Contain]
    public string? Description { get; set; }

    public int? Capacity { get; set; }
    
    public int? ManufactureYear { get; set; }
    
    public GearType? GearType { get; set; }
    
    public FuelType? FuelType { get; set; }

    public VehicleStatus? VehicleStatus { get; set; }
    
    public ModelStatus Status { get; set; }

    public int? CreateById { get; set; }


    public int? UpdateById { get; set; }


    public int? DeleteById { get; set; }
}
