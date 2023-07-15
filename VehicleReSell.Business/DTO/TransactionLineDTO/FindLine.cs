using CrudApiTemplate.Attributes.Search;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.TransactionLineDto;

public class FindLine: IFindRequest<TransactionLine>
{
    public int? Id { get; set; }
    
    [In(nameof(Entity.Id))]
    public IList<int>? Ids { get; set; }

    public int? TransactionId { get; set; }

    public int? VehicleId { get; set; }

    public int? WareHouseId { get; set; }

    public int? PICId { get; set; }

}