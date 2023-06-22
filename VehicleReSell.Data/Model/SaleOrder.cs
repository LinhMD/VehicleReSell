using CrudApiTemplate.Model;

namespace VehicleReSell.Data.Model;
public class SaleOrder : BaseModel
{
    public int Id { get; set; }

    public int? SellerId { get; set; }
    public Seller? Seller { get; set; }

    public int? TransactionId { get; set; }
    public Transaction? Transaction { get; set; }

    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }


}