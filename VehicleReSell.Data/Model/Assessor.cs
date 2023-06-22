namespace VehicleReSell.Data.Model;
public class Assessor : Entity
{
    public int? UserId { get; set; }
    
    public User? User { get; set; }

    public IList<ItemReceipt> ItemReceipts { get; set; } = new List<ItemReceipt>();
}