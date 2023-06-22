using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Business.DTO.TransactionLineDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.TransactionDto;

public class UpdateTransaction : UpdateDto, IUpdateRequest<Transaction>
{
    public int Id { get; set; }
    public string TransactionName { get; set; } = string.Empty;

    public long TotalAmount { get; set; } = 0;

    public DateTime TransactionDate { get; set; } = DateTime.Now;

    public TransactionType TransactionType { get; set; }

    public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.Open;

    public TransactionStatus TransactionStatus { get; set; } = TransactionStatus.Open;

    public IList<UpdateLine> TransactionLines { get; set; } = new List<UpdateLine>();
}
