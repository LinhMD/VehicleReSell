using CrudApiTemplate.Attributes.Search;
using CrudApiTemplate.CustomBinding;
using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.TransferOrderDto;

public class FindTransferOrder : IFindRequest<TransferOrder>
{
    public int? Id { get; set; }

    public int? StaffId { get; set; }

    [FromClaim("StaffId")]
    [Equal("StaffId")]
    public int? StaffIdHidden { get; set; }

    public int? TransactionId { get; set; }

    public int? FromLocationId { get; set; }
    [Contain]
    public string? FromLocationAddress { get; set; }

    public int? ToLocationId { get; set; }
    [Contain]
    public string? ToLocationAddress { get; set; }
    public ApprovalStatus? ApprovalStatus { get; set; }
    public ModelStatus? Status { get; set; }

    public int? CreateById { get; set; }


    public int? UpdateById { get; set; }


    public int? DeleteById { get; set; }

    public int? SaleOrderId { get; set; }

    public int? ItemReceiptId { get; set; }

    public TransferOrderType? TransferOrderType { get; set; }
}
