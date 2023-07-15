using CrudApiTemplate.Model;

namespace VehicleReSell.Data.Model;

public class Transaction : BaseModel,  IOrderAble
{
    public int Id { get; set; }

    public string TransactionName { get; set; }  

    public long TotalAmount { get; set; }

    public DateTime TransactionDate { get; set; }

    public TransactionType TransactionType { get; set; }

    

    public TransactionStatus TransactionStatus { get; set; }

    public IList<TransactionLine> TransactionLines { get; set; } = new List<TransactionLine>();

    public void ConfigOrderBy()
    {
        SetUpOrderBy<Transaction>();
    }
}
