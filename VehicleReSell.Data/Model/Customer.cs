namespace VehicleReSell.Data.Model;

public class Customer : Entity
{
    public IList<CustomerEvent> CustomerEvents { get; set; } = new List<CustomerEvent>();
}
