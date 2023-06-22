using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.EntityDto;

public class UpdateEntity : UpdateDto , IUpdateRequest<Entity>
{

    public string? Name { get; set; } 

    public string? Phone { get; set; } 

    public string? Address { get; set; } 

}
