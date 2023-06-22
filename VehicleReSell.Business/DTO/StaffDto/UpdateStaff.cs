using CrudApiTemplate.Request;
using VehicleReSell.Business.DTO.EntityDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.StaffDto;

public class UpdateStaff : UpdateEntity, IUpdateRequest<Staff>
{
}
