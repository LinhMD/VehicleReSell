using CrudApiTemplate.View;
using VehicleReSell.Business.DTO.EntityDto;
using VehicleReSell.Business.DTO.SaleOrderDto;
using VehicleReSell.Business.DTO.TransferOrderDto;
using VehicleReSell.Business.DTO.UserDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.StaffDto;

public class StaffSView : EntitySView, IView<Staff>
{
    public UserSView User { get; set; }
}
