using Mapster;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.WareHouseDto;

public class WareHouseSView
{
    public int Id { get; set; }

    public string Name { get; set; } 

    public string Phone { get; set; }

    public string Address { get; set; }

    public int MaxCapacity { get; set; }

    public Capacity Capacity { get; set; }
    
    public int AvailableCapacity { get; set; }
    
    public void InitMapper()
    {
        TypeAdapterConfig<WareHouse, WareHouseSView>.NewConfig();
    }

}