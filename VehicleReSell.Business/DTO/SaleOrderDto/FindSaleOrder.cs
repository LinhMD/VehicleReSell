using CrudApiTemplate.Attributes.Search;
using CrudApiTemplate.CustomBinding;
using CrudApiTemplate.Model;
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
    
    [FromClaim("SellerId")]
    [Equal("SellerId")]
    public int? SellerIdHidden { get; set; }
    
    public int? CustomerId { get; set; }

    public ApprovalStatus ApprovalStatus { get; set; }
    
    public ModelStatus Status { get; set; }

    public int? CreateById { get; set; }


    public int? UpdateById { get; set; }


    public int? DeleteById { get; set; }
}
