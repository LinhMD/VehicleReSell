using CrudApiTemplate.Model;

namespace VehicleReSell.Data.Model;

public class Customer : Entity, IOrderAble
{
    public IList<CustomerEvent> CustomerEvents { get; set; } = new List<CustomerEvent>();
    public new void ConfigOrderBy()
    {
        SetUpOrderBy<Customer>();
    }
}
