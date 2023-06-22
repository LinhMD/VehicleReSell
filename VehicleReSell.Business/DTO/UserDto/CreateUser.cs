using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.UserDto;

public class CreateUser : CreateDto, ICreateRequest<User>
{
    [Required]
    public string UserName { get; set; } = string.Empty;

    [Required]
    public Role Role { get; set; }
}
