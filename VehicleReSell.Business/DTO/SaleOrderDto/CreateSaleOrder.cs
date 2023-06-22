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

    public int? StaffId { get; set; }

    public int? AssessorId { get; set; }

    public ItemReceiptStatus ItemReceiptStatus { get; set; }

    public int? Approver { get; set; }

    public async Task<ItemReceipt> CreateNewAsync(IUnitOfWork work)
    {
        if (Transaction is null) return await Task.FromResult(this.Adapt<ItemReceipt>());
        var transaction = await work.Get<Transaction>().AddAsync(Transaction.Adapt<Transaction>());
            
        TransactionId = transaction.Id;
        var transactionLines = Transaction.TransactionLines.Select(line => line.Adapt<TransactionLine>()).Select(async line =>
        {
            line.TransactionId = transaction.Id;
            await work.Get<TransactionLine>().AddAsync(line);
            return line;
        });
        await Task.WhenAll(transactionLines);
        return await Task.FromResult(this.Adapt<ItemReceipt>());
    }
}