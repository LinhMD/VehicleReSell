using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.Model;
using CrudApiTemplate.Repository;
using CrudApiTemplate.Request;
using Mapster;
using VehicleReSell.Business.DTO.TransactionDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.TransferOrderDto;

public class CreateTransferOrder : CreateDto, ICreateRequest<TransferOrder>
{
    [Required]
    public int StaffId { get; set; }
    
    [AdaptIgnore]
    public CreateTransaction? Transaction { get; set; }
    public int? TransactionId { get; set; }

    public int? FromLocationId { get; set; }
    public string FromLocationAddress { get; set; } = string.Empty;
    public DateTime? LeaveDate { get; set; }


    public int? ToLocationId { get; set; }
    public string ToLocationAddress { get; set; } = string.Empty;
    public DateTime? ReceiveDate { get; set; }
    public async Task<TransferOrder> CreateNewAsync(IUnitOfWork work)
    {
        if (Transaction is null) return await Task.FromResult(this.Adapt<TransferOrder>());
        var transaction = await work.Get<Transaction>().AddAsync(Transaction.Adapt<Transaction>());
            
        TransactionId = transaction.Id;
        var transactionLines = Transaction.TransactionLines.Select(line => line.Adapt<TransactionLine>()).Select(async line =>
        {
            line.TransactionId = transaction.Id;
            await work.Get<TransactionLine>().AddAsync(line);
            return line;
        });
        await Task.WhenAll(transactionLines);
        return await Task.FromResult(this.Adapt<TransferOrder>());
    }
}
