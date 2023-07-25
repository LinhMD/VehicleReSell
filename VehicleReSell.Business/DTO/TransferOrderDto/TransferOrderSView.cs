using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using Mapster;
using VehicleReSell.Business.DTO.ItemReceiptDto;
using VehicleReSell.Business.DTO.SaleOrderDto;
using VehicleReSell.Business.DTO.StaffDto;
using VehicleReSell.Business.DTO.TransactionDto;
using VehicleReSell.Business.DTO.UserDto;
using VehicleReSell.Business.DTO.WareHouseDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.TransferOrderDto;

public class TransferOrderSView : BaseModel, IView<TransferOrder>, IDto
{
    public int Id { get; set; }

    public int? StaffId { get; set; }
    public StaffSView? Staff { get; set; }
    public TransactionSView? Transaction { get; set; }
    public int? TransactionId { get; set; }

    public int? FromLocationId { get; set; }
    public string FromLocationAddress { get; set; }
    public DateTime? LeaveDate { get; set; }

    public int? ToLocationId { get; set; }
    public string ToLocationAddress { get; set; }
    public DateTime? ReceiveDate { get; set; }

    public ApprovalStatus ApprovalStatus { get; set; }
    public SaleOrderSView? SaleOrder { get; set; }

    public ItemReceiptSView? ItemReceipt { get; set; }

    public TransferOrderType? TransferOrderType { get; set; }
    public UserSView? Approver { get; set; }
    public void InitMapper()
    {
        TypeAdapterConfig<TransferOrder, TransferOrderSView>.NewConfig();
    }
}
