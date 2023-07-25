using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.CustomBinding;
using CrudApiTemplate.Model;
using CrudApiTemplate.Repository;
using CrudApiTemplate.Request;
using Mapster;
using VehicleReSell.Business.DTO.TransactionDto;
using VehicleReSell.Data.Model;

using Microsoft.EntityFrameworkCore;

namespace VehicleReSell.Business.DTO.ItemReceiptDto;

public class CreateItemReceipt : CreateDto, ICreateRequest<ItemReceipt>
{
    public int? TransactionId { get; set; }
    [AdaptIgnore]
    public CreateTransaction? Transaction { get; set; }

    [FromClaim("StaffId")]
    public int? StaffId { get; set; }

    public int? AssessorId { get; set; }


    public int? VehicleOwnerId { get; set; }

    public ItemReceiptStatus ItemReceiptStatus { get; set; }

    public int? Approver { get; set; }
    public string? Request { get; set; }

    public string? Img { get; set; }

    public async Task<ItemReceipt> CreateNewAsync(IUnitOfWork work)
    {
        if (Transaction is null) return await Task.FromResult(this.Adapt<ItemReceipt>());
        var transaction = await work.Get<Transaction>().AddAsync(Transaction.Adapt<Transaction>());
        this.TransactionId = transaction.Id;
        var dict = await work.Get<Vehicle>()
            .Find(v => Transaction.TransactionLines.Select(l => l.VehicleId).Contains(v.Id))
            .Select(v => new { v.Id, v.AssessPrice })
            .ToDictionaryAsync(v => v.Id);
        foreach (var transactionLine in Transaction.TransactionLines.Select(line => line.Adapt<TransactionLine>()))
        {
            transactionLine.TransactionId = transaction.Id;
            await work.Get<TransactionLine>().AddAsync(transactionLine);
        }
        return await Task.FromResult(this.Adapt<ItemReceipt>());
    }

    public override void InitMapper()
    {
        TypeAdapterConfig<CreateItemReceipt, ItemReceipt>.NewConfig().Ignore(receipt => receipt.Approver);
    }
}