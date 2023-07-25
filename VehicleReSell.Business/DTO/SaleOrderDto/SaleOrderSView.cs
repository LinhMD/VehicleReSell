using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using Mapster;
using VehicleReSell.Business.DTO.CustomerDto;
using VehicleReSell.Business.DTO.SellerDto;
using VehicleReSell.Business.DTO.TransactionDto;
using VehicleReSell.Business.DTO.UserDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.SaleOrderDto;

public class SaleOrderSView : BaseModel, IView<SaleOrder>, IDto
{
    public int Id { get; set; }

    public TransactionSView? Transaction { get; set; }

    public CustomerSView? Customer { get; set; }

    public SellerSView? Seller { get; set; }

    public ApprovalStatus ApprovalStatus { get; set; }

    public UserSView? Approver { get; set; }
    public void InitMapper()
    {
        TypeAdapterConfig<SaleOrder, SaleOrderSView>.NewConfig();
    }
}
