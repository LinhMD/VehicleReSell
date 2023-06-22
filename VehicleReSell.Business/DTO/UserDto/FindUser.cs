using CrudApiTemplate.Attributes.Search;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.UserDto;

public class FindUser : IFindRequest<User>
{
    [Equal]
    public int? Id { get; set; }

    [In(nameof(User.Id))]
    public IList<int>? Ids { get; set; }

    [Contain]
    public string? UserName { get; set; } = string.Empty;

    [Equal]
    public Role? Role { get; set; }
}
