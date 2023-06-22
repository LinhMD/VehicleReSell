using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using VehicleReSell.Business.DTO.AssessorDto;
using VehicleReSell.Business.DTO.VehicleOwnerDto;
using VehicleReSell.Business.DTO.WareHouseDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.VehicleDto;

public class VehicleSView :  IView<Vehicle>, IDto
{
    public int Id { get; set; }

    public string? Name { get; set; } = string.Empty;

    public DateTime? NewAt { get; set; }

    public string? Color { get; set; } = string.Empty;

    public string? Manufacture { get; set; } = string.Empty;

    public CarModel CarModel { get; set; }

    public long? AssessPrice { get; set; }
    public long? SoldPrice { get; set; }

    public int? AssessorId { get; set; }
    public AssessorSView? Assessor { get; set; }

    public int? WareHouseId { get; set; }
    public WareHouseSView? WareHouse { get; set; }

    public int? VehicleOwnerId { get; set; }
    public VehicleOwnerSView? VehicleOwner { get; set; }

    public int? Usage { get; set; }

    public string? Description { get; set; } = string.Empty;

    public string? Imgs { get; set; } = string.Empty;

    public string? Videos { get; set; } = string.Empty;

    public int? Capacity { get; set; }
}
