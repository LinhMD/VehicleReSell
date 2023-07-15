using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using Mapster;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.UserDto;

public class UserSView :BaseModel, IView<User>, IDto
{
    public int Id { get; set; }

    public string UserName { get; set; } 
    public Role Role { get; set; }
    
    public string Email { get; set; }
    
    public string? AvatarLink { get; set; }

    public string? Phone { get; set; }
    public void InitMapper()
    {
        TypeAdapterConfig<User, UserSView>.NewConfig();
    }
}
