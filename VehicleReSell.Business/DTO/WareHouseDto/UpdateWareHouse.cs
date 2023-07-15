using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using CrudApiTemplate.View;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.WareHouseDto;

public class UpdateWareHouse : UpdateDto, IUpdateRequest<WareHouse>
{
    public string? Name { get; set; }  

    public string? Phone { get; set; }  
    
    public string? Address { get; set; }  

    public int? MaxCapacity { get; set; }

    public int? CurrentCapacity { get; set; }
}
