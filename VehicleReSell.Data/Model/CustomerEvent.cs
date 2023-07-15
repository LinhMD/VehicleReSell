using CrudApiTemplate.Model;

namespace VehicleReSell.Data.Model;

public class CustomerEvent : BaseModel, IOrderAble
{
    public int Id { get; set; }

    public int? SellerId { get; set; }
    public Seller? Seller { get; set; }

    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public int? VehicleId { get; set; }
    public Vehicle? Vehicle { get; set; }

    public string? Note { get; set; }  

    public DateTime? Date { get; set; }


    public void ConfigOrderBy()
    {
        SetUpOrderBy<CustomerEvent>();
    }
}
