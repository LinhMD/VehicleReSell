using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using Mapster;
using VehicleReSell.Business.DTO.TransactionDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.ItemReceiptDto;

public class UpdateItemReceipt : UpdateDto, IUpdateRequest<ItemReceipt>
{
    [AdaptIgnore]
    public UpdateTransaction? Transaction { get; set; }

    public int? StaffId { get; set; }

    public int? AssessorId { get; set; }

    public int? VehicleOwnerId { get; set; }
    public ItemReceiptStatus ItemReceiptStatus { get; set; }

    public int? Approver { get; set; }

    public string? Request { get; set; }

    public string? Img { get; set; }
}
