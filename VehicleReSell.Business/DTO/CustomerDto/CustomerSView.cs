using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using VehicleReSell.Business.DTO.CustomerEventDto;
using VehicleReSell.Business.DTO.EntityDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.CustomerDto;

public class CustomerSView : EntitySView, IView<Customer>, IDto
{
}
