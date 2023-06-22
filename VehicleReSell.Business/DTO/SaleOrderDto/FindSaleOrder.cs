using CrudApiTemplate.Attributes.Search;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.SaleOrderDto;

public class FindSaleOrder : IFindRequest<SaleOrder>
{
    public int? Id { get; set; }
    [In(nameof(ItemReceipt.Id))]
    public IList<int>? Ids { get; set; }
    
    public int? TransactionId { get; set; }
    
    public int? SellerId { get; set; }
    
    public int? CustomerId { get; set; }

    public ItemReceiptStatus? ItemReceiptStatus { get; set; }
    
   
}
