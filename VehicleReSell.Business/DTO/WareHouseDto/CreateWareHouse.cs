using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using Mapster;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.WareHouseDto;

public class CreateWareHouse : CreateDto, ICreateRequest<WareHouse>
{
    [Required]
    public string Name { get; set; }  

    public string Phone { get; set; }  
    [Required]
    public string Address { get; set; }  

    public int MaxCapacity { get; set; }

    public Capacity Capacity { get; set; } = Capacity.Low;

    public override void InitMapper()
    {
        TypeAdapterConfig<CreateWareHouse, WareHouse>.NewConfig()
            .Map(curr => curr.AvailableCapacity, create => create.MaxCapacity);
    }
}
