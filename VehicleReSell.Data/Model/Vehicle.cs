using CrudApiTemplate.Model;

namespace VehicleReSell.Data.Model;

public class Vehicle : BaseModel
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

}
