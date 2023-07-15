using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.Model;
using Microsoft.EntityFrameworkCore;

namespace VehicleReSell.Data.Model;

[Index(nameof(Email), IsUnique = true)]
public class User : BaseModel, IOrderAble
{
    public int Id { get; set; }

    public string UserName { get; set; } 
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Phone]
    public string? Phone { get; set; }

    public string Hash { get; set; }

    public string Salt { get; set; }
    public Role Role { get; set; }

    public string? AvatarLink { get; set; }
    public void ConfigOrderBy()
    {
        SetUpOrderBy<User>();
    }
}