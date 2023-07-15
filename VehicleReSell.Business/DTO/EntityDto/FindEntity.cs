using CrudApiTemplate.Attributes.Search;
using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.EntityDto;

public class FindEntity : IFindRequest<Entity>
{
    [Equal]
    public int? Id { get; set; }
    
    [In(nameof(Entity.Id))]
    public IList<int>? Ids { get; set; }
    
    [Contain]
    public string? Name { get; set; } 

    [Contain]
    public string? Phone { get; set; }

    [Contain]
    public string? Address { get; set; }

    public EntityType? EntityType { get; set; }
    
    public ModelStatus? Status { get; set; }

    public int? CreateById { get; set; }


    public int? UpdateById { get; set; }


    public int? DeleteById { get; set; }
}
