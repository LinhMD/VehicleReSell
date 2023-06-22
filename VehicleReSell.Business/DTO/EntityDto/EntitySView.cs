using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.EntityDto;

public class EntitySView : IView<Entity>, IDto
{
    public int Id { get; set; }

    public string Name { get; set; } 

    public string Phone { get; set; } 

    public string? Address { get; set; }

    public EntityType EntityType { get; set; }
}
