using System.ComponentModel.DataAnnotations.Schema;
using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using Mapster;
using VehicleReSell.Business.DTO.TransactionDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.SaleOrderDto;

public class UpdateSaleOrder : UpdateDto, IUpdateRequest<SaleOrder>
{
    public int Id { get; set; }

    [AdaptIgnore]
    public UpdateTransaction? Transaction { get; set; }

    public int? SellerId { get; set; }

    public int? CustomerId { get; set; }
    public ApprovalStatus? ApprovalStatus { get; set; }
    public string? Note { get; set; }
}
