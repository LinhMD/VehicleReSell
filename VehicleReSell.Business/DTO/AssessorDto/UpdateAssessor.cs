using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Business.DTO.EntityDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.AssessorDto;

public class UpdateAssessor : UpdateEntity, IUpdateRequest<Assessor>
{
}
