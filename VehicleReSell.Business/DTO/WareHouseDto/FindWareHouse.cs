using CrudApiTemplate.Attributes.Search;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.WareHouseDto;

public class FindWareHouse : IFindRequest<WareHouse>
{
    public int? Id { get; set; }
    [In(nameof(WareHouse.Id))]
    public IList<int>? Ids { get; set; }
    public string? Name { get; set; } 
    public string? Phone { get; set; } 

    public string? Address { get; set; } 

    public int? MaxCapacity { get; set; }

    public int? CurrentCapacity { get; set; }
}
