using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Business.DTO.EntityDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.AssessorDto;

public class CreateAssessor : CreateEntity, ICreateRequest<Assessor>
{
    public int? UserId { get; set; }

    public EntityType EntityType => EntityType.Assessor;
}
