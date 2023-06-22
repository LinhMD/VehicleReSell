using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using VehicleReSell.Business.DTO.StaffDto;
using VehicleReSell.Business.DTO.TransactionDto;
using VehicleReSell.Business.DTO.WareHouseDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.TransferOrderDto;

public class TransferOrderSView :  IView<TransferOrder>, IDto
{
    public int Id { get; set; }

    public int? StaffId { get; set; }
    public StaffSView? Staff { get; set; }
    public TransactionSView? Transaction { get; set; }
    public int? TransactionId { get; set; }

    public int? FromLocationId { get; set; }
    public string FromLocationAddress { get; set; } = string.Empty;
    public DateTime? LeaveDate { get; set; }

    public int? ToLocationId { get; set; }
    public string ToLocationAddress { get; set; } = string.Empty;
    public DateTime? ReceiveDate { get; set; }

}
