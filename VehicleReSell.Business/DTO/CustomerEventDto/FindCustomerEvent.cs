using CrudApiTemplate.Attributes.Search;
using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.CustomerEventDto;

public class FindCustomerEvent : IFindRequest<CustomerEvent>
{
    public int? Id { get; set; }

    [In(nameof(CustomerEvent.Id))]
    public IList<int>? Ids { get; set; }

    public int? SellerId { get; set; }

    public int? CustomerId { get; set; }

    public int? VehicleId { get; set; }

    public string? Note { get; set; }  

    public DateTime? Date { get; set; }
    
    public ModelStatus? Status { get; set; }

    public int? CreateById { get; set; }


    public int? UpdateById { get; set; }


    public int? DeleteById { get; set; }
}
