using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CrudApiTemplate.Model;

namespace VehicleReSell.Data.Model;

public class TransactionLine : BaseModel, IOrderAble
{
    
    public int Id { get; set; }

    public int TransactionId { get; set; }
    [JsonIgnore]
    public Transaction Transaction { get; set; }

    public int? VehicleId { get; set; }
    [JsonIgnore]
    public Vehicle? Vehicle { get; set; }

    public int? WareHouseId { get; set; }
    [JsonIgnore]
    public WareHouse? WareHouse { get; set; }

    public int? PICId { get; set; }
    [JsonIgnore]
    public User? PIC { get; set; }

    [Range(0, long.MaxValue)]
    public long Amount { get; set; }

    public string? Note { get; set; }

    public void ConfigOrderBy()
    {
        SetUpOrderBy<TransactionLine>();
    }
}
