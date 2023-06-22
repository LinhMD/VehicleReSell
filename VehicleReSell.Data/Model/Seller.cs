namespace VehicleReSell.Data.Model;
public class Seller : Entity
{
    public User? User { get; set; }

    public IList<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();

}