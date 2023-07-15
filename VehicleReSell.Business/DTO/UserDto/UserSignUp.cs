using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.Model;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.UserDto;

public class UserSignUp : CreateDto
{
    [Required] [EmailAddress] public string Email { get; set; }

    [Required] [MaxLength(255)] public string UserName { get; set; }

    [Required]
    [MinLength(8)]
    [MaxLength(32)]
    public string Password { get; set; }

    [Required] public Role Role { get; set; }

    [Phone]public string? PhoneNumber { get; set; }
    
}