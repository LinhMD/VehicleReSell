using CrudApiTemplate.Request;
using VehicleReSell.Business.DTO.EntityDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.SellerDto;

public class FindSeller : FindEntity, IFindRequest<Seller>
{
    public int? UserId { get; set; }
}
