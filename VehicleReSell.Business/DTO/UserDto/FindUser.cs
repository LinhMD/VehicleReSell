using CrudApiTemplate.Attributes.Search;
using CrudApiTemplate.Model;
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
    public string? UserName { get; set; }  
 
    [Equal]
    public Role? Role { get; set; }
    
    public ModelStatus? Status { get; set; }

    public int? CreateById { get; set; }


    public int? UpdateById { get; set; }


    public int? DeleteById { get; set; }
}
