using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.CustomerEventDto;

public class UpdateCustomerEvent : UpdateDto, IUpdateRequest<CustomerEvent>
{
    public int? SellerId { get; set; }

    public int? CustomerId { get; set; }

    public int? VehicleId { get; set; }

    public string? Note { get; set; } 

    public DateTime? Date { get; set; }
}
