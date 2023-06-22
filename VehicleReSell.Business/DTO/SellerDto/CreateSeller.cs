using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Business.DTO.EntityDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.SellerDto;

public class CreateSeller : CreateEntity, ICreateRequest<Seller>
{
    public int? UserId { get; set; }
    public EntityType EntityType  => EntityType.Seller;
}
