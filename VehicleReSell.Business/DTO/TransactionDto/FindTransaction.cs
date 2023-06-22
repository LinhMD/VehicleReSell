using CrudApiTemplate.Attributes.Search;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.TransactionDto;

public class FindTransaction : IFindRequest<Transaction>
{
    [Equal]
    public int? Id { get; set; }

    [Contain]
    public string? TransactionName { get; set; }

    [Equal]
    public long? TotalAmount { get; set; }
    
    [Equal]
    public DateTime? TransactionDate { get; set; }
    
    [Equal]
    public TransactionType? TransactionType { get; set; }
    
    [Equal]
    public ApprovalStatus? ApprovalStatus { get; set; }
    
    [Equal]
    public TransactionStatus? TransactionStatus { get; set; }

}
