using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using Mapster;
using VehicleReSell.Business.DTO.TransactionDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.TransferOrderDto;

public class UpdateTransferOrder : UpdateDto, IUpdateRequest<TransferOrder>
{
    public int? StaffId { get; set; }
    public int? TransactionId { get; set; }

    public int? FromLocationId { get; set; }
    public string? FromLocationAddress { get; set; }
    public DateTime? LeaveDate { get; set; }


    public int? ToLocationId { get; set; }
    public string? ToLocationAddress { get; set; }
    public DateTime? ReceiveDate { get; set; }
    public ApprovalStatus? ApprovalStatus { get; set; }
    public int? SaleOrderId { get; set; }

    public int? ItemReceiptId { get; set; }

    [AdaptIgnore]
    public UpdateTransaction? Transaction { get; set; }

    public int? ApproverId { get; set; }


}
