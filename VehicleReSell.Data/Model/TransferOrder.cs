using CrudApiTemplate.Model;

namespace VehicleReSell.Data.Model;
public class TransferOrder : BaseModel
{
    public int Id { get; set; }

    public int? StaffId { get; set; }
    public Staff? Staff { get; set; }
    public Transaction? Transaction { get; set; }
    public int? TransactionId { get; set; }

    public WareHouse? FromLocation { get; set; }
    public int? FromLocationId { get; set; }
    public string FromLocationAddress { get; set; } = string.Empty;
    public DateTime? LeaveDate { get; set; }

    public WareHouse? ToLocation { get; set; }
    public int? ToLocationId { get; set; }
    public string ToLocationAddress { get; set; } = string.Empty;
    public DateTime? ReceiveDate { get; set; }

}