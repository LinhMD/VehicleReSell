using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Business.DTO.EntityDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.VehicleOwnerDto;

public class CreateVehicleOwner : CreateEntity, ICreateRequest<VehicleOwner>
{
    public EntityType EntityType  => EntityType.VehicleOwner;
}
