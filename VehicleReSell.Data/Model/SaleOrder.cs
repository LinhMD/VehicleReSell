using CrudApiTemplate.Model;

namespace VehicleReSell.Data.Model;
public class SaleOrder : BaseModel, IOrderAble
{
    public int Id { get; set; }

    public int? SellerId { get; set; }
    public Seller? Seller { get; set; }

    public int? TransactionId { get; set; }
    public Transaction? Transaction { get; set; }

    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }
    
    public ApprovalStatus ApprovalStatus { get; set; }

    public string? Note { get; set; }
    public void ConfigOrderBy()
    {
        SetUpOrderBy<SaleOrder>();
    }
}