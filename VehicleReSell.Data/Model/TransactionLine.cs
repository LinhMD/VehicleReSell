using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.Model;

namespace VehicleReSell.Data.Model;

public class TransactionLine : BaseModel
{
    
    public int Id { get; set; }

    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }

    public int? VehicleId { get; set; }

    public Vehicle? Vehicle { get; set; }

    public int? WareHouseId { get; set; }
    public WareHouse? WareHouse { get; set; }

    public int? PICId { get; set; }
    public User? PIC { get; set; }

    [Range(0, long.MaxValue)]
    public long Amount { get; set; }

    public string Note { get; set; } = string.Empty;

}
