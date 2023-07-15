using CrudApiTemplate.Model;

namespace VehicleReSell.Data.Model;
public class ItemReceipt : BaseModel, IOrderAble
{
    public int Id { get; set; }
    
    public int? TransactionId { get; set; }
    
    public Transaction? Transaction { get; set; }

    public int? StaffId { get; set; }
    
    public Staff? Staff { get; set; }
    
    public int? AssessorId { get; set; }
    
    public Assessor? Assessor { get; set; }

    public int? VehicleOwnerId { get; set; }
    public VehicleOwner? VehicleOwner { get; set; }
    public ItemReceiptStatus ItemReceiptStatus { get; set; }
    
    public int? ApproverId { get; set; }
    
    public User? Approver { get; set; }

    public string? Request { get; set; }

    public string? Img { get; set; }
    public void ConfigOrderBy()
    {
        SetUpOrderBy<ItemReceipt>();
    }
}