using CrudApiTemplate.Model;

namespace VehicleReSell.Data.Model;

public class WareHouse : BaseModel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public IList<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    public int? MaxCapacity { get; set; }

    public int? CurrentCapacity { get; set; }
}
