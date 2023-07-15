using CrudApiTemplate.Model;

namespace VehicleReSell.Data.Model;
public class Staff : Entity, IOrderAble
{
    public int? UserId { get; set; }
    public User? User { get; set; }

    public IList<TransferOrder> TransferOrders { get; set; } = new List<TransferOrder>();
    
    public void ConfigOrderBy()
    {
        SetUpOrderBy<Staff>();
    }
}