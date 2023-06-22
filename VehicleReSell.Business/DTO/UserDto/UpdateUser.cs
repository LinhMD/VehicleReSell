using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.UserDto;

public class UpdateUser : UpdateDto, IUpdateRequest<User>
{
    public string? UserName { get; set; } = string.Empty;

    public Role? Role { get; set; }
}
