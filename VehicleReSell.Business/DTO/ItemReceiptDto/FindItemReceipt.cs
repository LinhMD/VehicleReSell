using CrudApiTemplate.Attributes.Search;
using CrudApiTemplate.CustomBinding;
using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.ItemReceiptDto;

public class FindItemReceipt : IFindRequest<ItemReceipt>
{
    public int? Id { get; set; }
    [In(nameof(ItemReceipt.Id))]
    public IList<int>? Ids { get; set; }
    
    public int? TransactionId { get; set; }
    
    // [FromClaim("StaffId")]
    // [Equal("StaffId")]
    // public int? StaffIdHidden { get; set; }
    
    public int? StaffId { get; set; }
    
    [FromClaim("AssessorId")]
    [Equal("AssessorId")]
    public int? AssessorIdHidden { get; set; }
    
    public int? AssessorId { get; set; }

    public ItemReceiptStatus? ItemReceiptStatus { get; set; }
    
    public int? ApproverId { get; set; }
    
    public ModelStatus? Status { get; set; }

    public int? CreateById { get; set; }


    public int? UpdateById { get; set; }


    public int? DeleteById { get; set; }
}
