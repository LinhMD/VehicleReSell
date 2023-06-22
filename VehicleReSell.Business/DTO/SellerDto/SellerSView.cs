
using CrudApiTemplate.View;
using VehicleReSell.Business.DTO.EntityDto;
using VehicleReSell.Business.DTO.SaleOrderDto;
using VehicleReSell.Business.DTO.UserDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.SellerDto;

public class SellerSView : EntitySView, IView<Seller>
{
    public UserSView User { get; set; }
    
}
