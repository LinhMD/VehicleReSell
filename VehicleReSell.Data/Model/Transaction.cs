using CrudApiTemplate.Model;

namespace VehicleReSell.Data.Model;

public class Transaction : BaseModel
{
    public int Id { get; set; }

    public string TransactionName { get; set; } = string.Empty;

    public long TotalAmount { get; set; }

    public DateTime TransactionDate { get; set; }

    public TransactionType TransactionType { get; set; }

    public ApprovalStatus ApprovalStatus { get; set; }

    public TransactionStatus TransactionStatus { get; set; }

    public IList<TransactionLine> TransactionLines { get; set; } = new List<TransactionLine>();

}
