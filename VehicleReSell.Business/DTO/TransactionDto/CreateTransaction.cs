using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using Mapster;
using VehicleReSell.Business.DTO.TransactionLineDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.TransactionDto;

public class CreateTransaction : CreateDto, ICreateRequest<Transaction>
{
    [Required]
    public string TransactionName { get; set; }  

    public long TotalAmount { get; set; }

    public DateTime TransactionDate { get; set; } = DateTime.Now;

    [Required]
    public TransactionType TransactionType { get; set; }

    [Required]
    public TransactionStatus TransactionStatus { get;  } = TransactionStatus.Open;
    [AdaptIgnore]
    public IList<CreateLine> TransactionLines { get; set; } = new List<CreateLine>();
}
