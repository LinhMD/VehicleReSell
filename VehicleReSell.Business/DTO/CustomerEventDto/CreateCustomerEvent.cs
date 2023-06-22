using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.CustomerEventDto;

public class CreateCustomerEvent : CreateDto, ICreateRequest<CustomerEvent>
{

    public int? SellerId { get; set; }

    [Required]
    public int? CustomerId { get; set; }
    
    [Required]
    public int? VehicleId { get; set; }

    public string? Note { get; set; } 

    public DateTime? Date { get; set; }
}
