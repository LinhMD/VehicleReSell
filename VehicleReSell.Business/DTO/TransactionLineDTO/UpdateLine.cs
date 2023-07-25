using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.Attributes.Update;
using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.TransactionLineDto;

public class UpdateLine : UpdateDto, IUpdateRequest<TransactionLine>
{
    [UpdateIgnore]
    public int Id { get; set; }
    public int? VehicleId { get; set; }

    public int? WareHouseId { get; set; }

    public int? PICId { get; set; }

    [Range(0, long.MaxValue)]
    public long Amount { get; set; }

    public string Note { get; set; }
}
