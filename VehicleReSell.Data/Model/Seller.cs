using CrudApiTemplate.Model;

namespace VehicleReSell.Data.Model;
public class Seller : Entity, IOrderAble
{
    public int? UserId { get; set; }
    public User? User { get; set; }

    public IList<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();

    public new void ConfigOrderBy()
    {
        SetUpOrderBy<Seller>();
    }
}