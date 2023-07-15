using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using Mapster;
using VehicleReSell.Business.DTO.VehicleDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.WareHouseDto;

public class WareHouseView :BaseModel,  IView<WareHouse>, IDto
{
    public int Id { get; set; }

    public string Name { get; set; } 

    public string Phone { get; set; }

    public string Address { get; set; }

    public IList<VehicleView> Vehicles { get; set; }

    public int VehiclesSold { get; set; }

    public int VehiclesOrdered { get; set; }
    
    public int Inventory { get; set; }

    public int MaxCapacity { get; set; }

    public Capacity Capacity { get; set; }
    
    public int AvailableCapacity { get; set; }
    
    public void InitMapper()
    {
        TypeAdapterConfig<WareHouse, WareHouseView>.NewConfig()
            .Map(view => view.VehiclesSold, house => house.Vehicles.Count(v => v.VehicleStatus == VehicleStatus.Sold))
            .Map(view => view.VehiclesOrdered, house => house.Vehicles.Count(v => v.VehicleStatus == VehicleStatus.Order))
            .Map(view => view.Inventory, house => house.Vehicles.Count(v => v.VehicleStatus == VehicleStatus.Inventory));
    }
}
