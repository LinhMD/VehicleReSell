using CrudApiTemplate.Attributes.Search;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.EntityDto;

public class FindEntity : IFindRequest<Entity>
{
    [Equal]
    public int? Id { get; set; }
    [In(nameof(Entity.Id))]
    public IList<int>? Ids { get; set; }
    public string? Name { get; set; } = string.Empty;

    public string? Phone { get; set; } = string.Empty;

    public string? Address { get; set; } = string.Empty;

    public EntityType? EntityType { get; set; }
}
