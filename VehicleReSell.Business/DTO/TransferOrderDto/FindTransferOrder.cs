using CrudApiTemplate.Attributes.Search;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.TransferOrderDto;

public class FindTransferOrder : IFindRequest<TransferOrder>
{
    public int? Id { get; set; }

    public int? StaffId { get; set; }
    public int? TransactionId { get; set; }

    public int? FromLocationId { get; set; }
    [Contain]
    public string? FromLocationAddress { get; set; } = string.Empty;

    public int? ToLocationId { get; set; }
    [Contain]
    public string? ToLocationAddress { get; set; } = string.Empty;
}
