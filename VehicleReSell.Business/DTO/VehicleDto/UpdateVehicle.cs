using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.VehicleDto;

public class UpdateVehicle : UpdateDto, IUpdateRequest<Vehicle>
{
    public string? Name { get; set; } = string.Empty;

    public DateTime? NewAt { get; set; }

    public string? Color { get; set; } = string.Empty;

    public string? Manufacture { get; set; } = string.Empty;

    public CarModel? CarModel { get; set; }

    public int? AssessorId { get; set; }

    public int? WareHouseId { get; set; }

    public int? VehicleOwnerId { get; set; }

    public int? Usage { get; set; }

    public string? Description { get; set; } = string.Empty;

    public string? Imgs { get; set; } = string.Empty;

    public string? Videos { get; set; } = string.Empty;

    public int? Capacity { get; set; }
}
