using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using VehicleReSell.Data.Model;
using System;
using VehicleReSell.Business.DTO.TransactionLineDto;

namespace VehicleReSell.Business.DTO.TransactionDto;

public class TransactionSView : IView<Transaction>, IDto
{
    public int Id { get; set; }

    public string TransactionName { get; set; } = string.Empty;

    public long TotalAmount { get; set; }

    public DateTime TransactionDate { get; set; }

    public TransactionType TransactionType { get; set; }

    public ApprovalStatus ApprovalStatus { get; set; }

    public TransactionStatus TransactionStatus { get; set; }

    public IList<LineSView> TransactionLines { get; set; } = new List<LineSView>();
}
