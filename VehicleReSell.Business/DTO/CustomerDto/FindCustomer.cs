using CrudApiTemplate.Attributes.Search;
using CrudApiTemplate.Request;
using VehicleReSell.Business.DTO.EntityDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.CustomerDto;

public class FindCustomer : FindEntity, IFindRequest<Customer>
{
    
}
