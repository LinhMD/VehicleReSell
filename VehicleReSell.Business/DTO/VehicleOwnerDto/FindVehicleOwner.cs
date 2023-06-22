using CrudApiTemplate.Attributes.Search;
using CrudApiTemplate.Request;
using VehicleReSell.Business.DTO.EntityDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.VehicleOwnerDto;

public class FindVehicleOwner : FindEntity,IFindRequest<VehicleOwner>
{
   
}
