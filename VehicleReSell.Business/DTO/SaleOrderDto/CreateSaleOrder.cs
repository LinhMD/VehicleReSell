using CrudApiTemplate.CustomBinding;
using CrudApiTemplate.Model;
using CrudApiTemplate.Repository;
using CrudApiTemplate.Request;
using Mapster;
using VehicleReSell.Business.DTO.TransactionDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.SaleOrderDto;

public class CreateSaleOrder : CreateDto, ICreateRequest<SaleOrder>
{
    public int? TransactionId { get; set; }
    [AdaptIgnore]
    public CreateTransaction? Transaction { get; set; }

    [FromClaim("SellerId")]
    public int? SellerId { get; set; }

    public int? CustomerId { get; set; }

    public int? ApproverId { get; set; }

    public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.Open;
    public string? Note { get; set; }
    async Task<SaleOrder> ICreateRequest<SaleOrder>.CreateNewAsync(IUnitOfWork work)
    {
        if (Transaction is null) return await Task.FromResult(this.Adapt<SaleOrder>());
        var transaction = await work.Get<Transaction>().AddAsync(Transaction.Adapt<Transaction>());
        this.TransactionId = transaction.Id;
        foreach (var transactionLine in Transaction.TransactionLines.Select(line => line.Adapt<TransactionLine>()))
        {
            transactionLine.TransactionId = transaction.Id;
            await work.Get<TransactionLine>().AddAsync(transactionLine);
        }
        return await Task.FromResult(this.Adapt<SaleOrder>());
    }

}