using System.Text.Json.Serialization;
using CrudApiTemplate.Model;

namespace VehicleReSell.Data.Model;

public class Vehicle : BaseModel, IOrderAble
{
    public int Id { get; set; }

    public string? Name { get; set; } 

    public DateTime? NewAt { get; set; }

    public string? Color { get; set; } 

    public string? Manufacture { get; set; } 

    public CarModel CarModel { get; set; }

    public long? AssessPrice { get; set; }
    
    public long? SoldPrice { get; set; }

    public int? AssessorId { get; set; }
    public Assessor? Assessor { get; set; }

    public int? WareHouseId { get; set; }
    public WareHouse? WareHouse { get; set; }

    public int? VehicleOwnerId { get; set; }
    public VehicleOwner? VehicleOwner { get; set; }

    public int? Usage { get; set; }

    public string? Description { get; set; } 

    public string? Imgs { get; set; }

    public string? Videos { get; set; }

    public int? Capacity { get; set; }
    
    public int? ManufactureYear { get; set; }
    public GearType GearType { get; set; }
    public FuelType FuelType { get; set; }
    public VehicleStatus VehicleStatus { get; set; } 
    
    public IList<VehicleImg> VehicleImgs { get; set; }
    public void ConfigOrderBy()
    {
        SetUpOrderBy<Vehicle>();
    }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GearType
{
    Automatic,
    Manual
}
    
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum FuelType
{
    Electric,
    Gas,
    Hybrid
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum VehicleStatus
{
    Draft,
    Inventory,
    Order,
    Sold
}