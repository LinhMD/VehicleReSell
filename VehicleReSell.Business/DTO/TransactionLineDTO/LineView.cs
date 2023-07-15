using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using Mapster;
using VehicleReSell.Business.DTO.VehicleDto;
using VehicleReSell.Business.DTO.WareHouseDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.TransactionLineDto;

public class LineView :  IView<TransactionLine>, IDto
{
    public int Id { get; set; }

    public int TransactionId { get; set; }

    public int? VehicleId { get; set; }
    public VehicleSView? Vehicle { get; set; }

    public int? WareHouseId { get; set; }
    public WareHouseSView? WareHouse { get; set; }

    public int? PICId { get; set; }
    public User? PIC { get; set; }

    public long Amount { get; set; }

    public string Note { get; set; }
    public void InitMapper()
    {
        TypeAdapterConfig<TransactionLine, LineView>.NewConfig();
    }
}