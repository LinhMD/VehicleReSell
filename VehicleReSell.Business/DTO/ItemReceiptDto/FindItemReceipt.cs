using CrudApiTemplate.Attributes.Search;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.ItemReceiptDto;

public class FindItemReceipt : IFindRequest<ItemReceipt>
{
    public int? Id { get; set; }
    [In(nameof(ItemReceipt.Id))]
    public IList<int>? Ids { get; set; }
    
    public int? TransactionId { get; set; }
    
    public int? StaffId { get; set; }
    
    public int? AssessorId { get; set; }

    public ItemReceiptStatus? ItemReceiptStatus { get; set; }
    
    public int? ApproverId { get; set; }
    
   
}
