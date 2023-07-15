using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using Mapster;
using VehicleReSell.Business.DTO.CustomerEventDto;
using VehicleReSell.Business.DTO.EntityDto;
using VehicleReSell.Business.DTO.SellerDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.CustomerDto;

public class CustomerSView : EntitySView, IView<Customer>, IDto
{ 
   public new void InitMapper()
   {
      TypeAdapterConfig<Seller, SellerSView>.NewConfig();
   }
}
