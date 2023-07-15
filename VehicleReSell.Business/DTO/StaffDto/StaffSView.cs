using CrudApiTemplate.View;
using Mapster;
using VehicleReSell.Business.DTO.EntityDto;
using VehicleReSell.Business.DTO.UserDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.StaffDto;

public class StaffSView : EntitySView, IView<Staff>
{
    public UserSView User { get; set; }
    public new void InitMapper()
    {
        TypeAdapterConfig<Staff, StaffSView>.NewConfig();
    }
}
