using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using VehicleReSell.Business.DTO.VehicleDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.WareHouseDto;

public class WareHouseSView :  IView<WareHouse>, IDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public IList<VehicleSView> Vehicles { get; set; } = new List<VehicleSView>();

    public int MaxCapacity { get; set; }

    public int CurrentCapacity { get; set; }
}
