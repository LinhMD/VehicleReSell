
using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using Mapster;
using VehicleReSell.Business.DTO.EntityDto;
using VehicleReSell.Business.DTO.SaleOrderDto;
using VehicleReSell.Business.DTO.UserDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.SellerDto;

public class SellerSView : EntitySView, IView<Seller>, IDto
{
    public int? UserId { get; set; }
    
    public UserSView User { get; set; }

    public new void InitMapper()
    {
        TypeAdapterConfig<Seller, SellerSView>.NewConfig();
    }
}
