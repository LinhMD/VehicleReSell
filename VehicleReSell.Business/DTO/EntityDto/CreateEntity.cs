using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.EntityDto;

public class CreateEntity : CreateDto, ICreateRequest<Entity>
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Phone]
    [Required]
    public string Phone { get; set; }
    
    public string? Address { get; set; } 

}
