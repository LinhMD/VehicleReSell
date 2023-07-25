using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.CustomBinding;
using CrudApiTemplate.Model;
using CrudApiTemplate.Repository;
using CrudApiTemplate.Request;
using Mapster;
using VehicleReSell.Business.DTO.TransactionDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.TransferOrderDto;

public class CreateTransferOrder : CreateDto, ICreateRequest<TransferOrder>
{
    [FromClaim("StaffId")]
    public int? StaffId { get; set; }

    [AdaptIgnore]
    public CreateTransaction? Transaction { get; set; }
    public int? TransactionId { get; set; }

    public int? FromLocationId { get; set; }
    public string FromLocationAddress { get; set; }
    public DateTime? LeaveDate { get; set; }

    public int? ToLocationId { get; set; }
    public string ToLocationAddress { get; set; }
    public DateTime? ReceiveDate { get; set; }
    public int? SaleOrderId { get; set; }

    public int? ItemReceiptId { get; set; }

    public int? ApproverId { get; set; }

    public ApprovalStatus? ApprovalStatus => Data.Model.ApprovalStatus.Open;

    public TransferOrderType? TransferOrderType { get; set; }
    public async Task<TransferOrder> CreateNewAsync(IUnitOfWork work)
    {
        if (Transaction is null) return await Task.FromResult(this.Adapt<TransferOrder>());
        var transaction = await work.Get<Transaction>().AddAsync(Transaction.Adapt<Transaction>());
        this.TransactionId = transaction.Id;
        foreach (var transactionLine in Transaction.TransactionLines.Select(line => line.Adapt<TransactionLine>()))
        {
            transactionLine.TransactionId = transaction.Id;
            await work.Get<TransactionLine>().AddAsync(transactionLine);
        }
        return await Task.FromResult(this.Adapt<TransferOrder>());
    }
}
