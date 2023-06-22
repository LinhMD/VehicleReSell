using CrudApiTemplate.Attributes.Search;
using CrudApiTemplate.Request;
using VehicleReSell.Business.DTO.EntityDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.AssessorDto;

public class FindAssessor : FindEntity, IFindRequest<Assessor>
{
    public int? UserId { get; set; }
}
