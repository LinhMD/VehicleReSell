namespace VehicleReSell.Data.Model;
public class Staff : Entity
{
    public int? UserId { get; set; }
    public User? User { get; set; }

    public IList<TransferOrder> TransferOrders { get; set; } = new List<TransferOrder>();
}