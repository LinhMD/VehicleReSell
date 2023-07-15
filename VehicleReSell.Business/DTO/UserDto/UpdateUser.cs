using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.UserDto;

public class UpdateUser : UpdateDto, IUpdateRequest<User>
{
    public string? UserName { get; set; } 
    public string? Email { get; set; }

    public string? Phone { get; set; }

    public Role? Role { get; set; }
    
    public string? AvatarLink { get; set; }
}
