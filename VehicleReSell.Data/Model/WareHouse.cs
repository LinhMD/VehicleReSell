using System.Text.Json.Serialization;
using CrudApiTemplate.Model;

namespace VehicleReSell.Data.Model;

public class WareHouse : BaseModel, IOrderAble
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public IList<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    public int? MaxCapacity { get; set; }

    public Capacity Capacity { get; set; }

    public int AvailableCapacity { get; set; }
    public void ConfigOrderBy()
    {
        SetUpOrderBy<WareHouse>();
    }
}
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Capacity
{
    Low,
    Medium,
    High
}
