using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using Mapster;
using VehicleReSell.Business.DTO.SellerDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.EntityDto;

public class EntitySView : BaseModel, IView<Entity>, IDto
{
    public int Id { get; set; }

    public string Name { get; set; } 

    public string Phone { get; set; } 

    public string? Address { get; set; }

    public EntityType EntityType { get; set; }
    public void InitMapper()
    {
        TypeAdapterConfig<Entity, EntitySView>.NewConfig();
    }
}
