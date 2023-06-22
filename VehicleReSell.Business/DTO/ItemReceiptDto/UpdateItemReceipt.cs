using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Business.DTO.TransactionDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.ItemReceiptDto;

public class UpdateItemReceipt : UpdateDto, IUpdateRequest<ItemReceipt>
{
    public int Id { get; set; }

    public UpdateTransaction? Transaction { get; set; }

    public int? StaffId { get; set; }

    public int? AssessorId { get; set; }

    public ItemReceiptStatus ItemReceiptStatus { get; set; }

    public int? Approver { get; set; }
}
