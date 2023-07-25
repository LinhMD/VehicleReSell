using CrudApiTemplate.Attributes.Update;
using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Business.DTO.TransactionLineDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.TransactionDto;

public class UpdateTransaction : UpdateDto, IUpdateRequest<Transaction>
{

    [UpdateIgnore]
    public int Id { get; set; }
    public string? TransactionName { get; set; }

    public long? TotalAmount { get; set; } = 0;

    public DateTime? TransactionDate { get; set; }

    public TransactionType? TransactionType { get; set; }

    public ApprovalStatus? ApprovalStatus { get; set; }

    public TransactionStatus? TransactionStatus { get; set; }

    public IList<UpdateLine>? TransactionLines { get; set; }
}
