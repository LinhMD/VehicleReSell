using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using Mapster;
using VehicleReSell.Business.DTO.EntityDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.VehicleOwnerDto;

public class VehicleOwnerSView : EntitySView, IView<VehicleOwner>
{
    public void InitMapper()
    {
        TypeAdapterConfig<VehicleOwner, VehicleOwnerSView>.NewConfig();
    }
}
