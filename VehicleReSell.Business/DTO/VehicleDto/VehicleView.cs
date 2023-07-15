using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using Mapster;
using VehicleReSell.Business.DTO.AssessorDto;
using VehicleReSell.Business.DTO.UserDto;
using VehicleReSell.Business.DTO.VehicleOwnerDto;
using VehicleReSell.Business.DTO.WareHouseDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.VehicleDto;

public class VehicleView :BaseModel,  IView<Vehicle>, IDto
{
    public int Id { get; set; }

    public string? Name { get; set; }  

    public DateTime? NewAt { get; set; }

    public string? Color { get; set; }  

    public string? Manufacture { get; set; }  

    public CarModel CarModel { get; set; }

    public long? AssessPrice { get; set; }
    public long? SoldPrice { get; set; }

    public int? AssessorId { get; set; }
    public UserSView? Assessor { get; set; }

    public int? WareHouseId { get; set; }

    public int? VehicleOwnerId { get; set; }

    public VehicleOwnerSView? VehicleOwner { get; set; }

    public int? Usage { get; set; }

    public string? Description { get; set; }  

    public string? Imgs { get; set; }  

    public string? Videos { get; set; }  

    public int? Capacity { get; set; }
    public int? ManufactureYear { get; set; }
    public GearType GearType { get; set; }
    public FuelType FuelType { get; set; }
    
    public VehicleStatus VehicleStatus { get; set; } 

    public IList<string> VehicleImgs { get; set; }
    public void InitMapper()
    {
        TypeAdapterConfig<Vehicle, VehicleView>.NewConfig()
            .Map(view => view.Assessor, vehicle => vehicle.Assessor == null ? null : vehicle.Assessor.User)
            .Map(view => view.VehicleImgs, vehicle => vehicle.VehicleImgs.Select(i => i.Image));
    }
}
