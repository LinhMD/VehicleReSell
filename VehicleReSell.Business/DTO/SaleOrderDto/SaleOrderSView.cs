using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using VehicleReSell.Business.DTO.CustomerDto;
using VehicleReSell.Business.DTO.TransactionDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.SaleOrderDto;

public class SaleOrderSView :  IView<SaleOrder>, IDto
{
    public int Id { get; set; }

    public TransactionSView? Transaction { get; set; }

    public SaleOrderSView? SaleOrder { get; set; }

    public CustomerSView? Customer { get; set; }


}
