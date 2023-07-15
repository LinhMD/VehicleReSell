using CrudApiTemplate.View;
using Mapster;
using VehicleReSell.Business.DTO.EntityDto;
using VehicleReSell.Business.DTO.UserDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.AssessorDto;

public class AssessorSView : EntitySView, IView<Assessor>
{
    public UserSView? User { get; set; }
    public new void InitMapper()
    {
        TypeAdapterConfig<Assessor, AssessorSView>.NewConfig();
    }
}
