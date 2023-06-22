using CrudApiTemplate.Request;
using VehicleReSell.Business.DTO.EntityDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.StaffDto;

public class CreateStaff : CreateEntity, ICreateRequest<Staff>
{
    public int? UserId { get; set; }
    public EntityType EntityType  => EntityType.Staff;
}
