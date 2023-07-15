using System.Linq.Expressions;
using CrudApiTemplate.Model;
using CrudApiTemplate.OrderBy;

namespace VehicleReSell.Data.Model;
public class Assessor : Entity, IOrderAble
{
    public int? UserId { get; set; }
    
    public User? User { get; set; }

    public IList<ItemReceipt> ItemReceipts { get; set; } = new List<ItemReceipt>();
    public new void ConfigOrderBy()
    {
        SetUpOrderBy<Assessor>();
        Expression<Func<Assessor, int?>> waiting = m => m.ItemReceipts.Count(i => i.ItemReceiptStatus == ItemReceiptStatus.WaitingForAssessment);
        OrderByProvider<Assessor>.OrderByDic.Add(nameof(ItemReceiptStatus.WaitingForAssessment), waiting);
    }
}