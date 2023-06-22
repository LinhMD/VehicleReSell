using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.WareHouseDto;

public class CreateWareHouse : CreateDto, ICreateRequest<WareHouse>
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;
    [Required]
    public string Address { get; set; } = string.Empty;

    public int MaxCapacity { get; set; }

    public int CurrentCapacity { get; set; }
}
