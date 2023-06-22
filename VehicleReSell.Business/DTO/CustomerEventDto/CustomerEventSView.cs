using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using VehicleReSell.Business.DTO.SellerDto;
using VehicleReSell.Business.DTO.VehicleDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.CustomerEventDto;

public class CustomerEventSView : IView<CustomerEvent>, IDto
{
    public int Id { get; set; }

    public int? SellerId { get; set; }
    
    public SellerSView? Seller { get; set; }

    public int? CustomerId { get; set; }

    public int? VehicleId { get; set; }
    
    public VehicleSView? Vehicle { get; set; }

    public string? Note { get; set; } = string.Empty;

    public DateTime? Date { get; set; }
}
