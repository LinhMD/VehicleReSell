using CrudApiTemplate.Model;
using VehicleReSell.Business.DTO.AssessorDto;
using VehicleReSell.Business.DTO.CustomerDto;
using VehicleReSell.Business.DTO.CustomerEventDto;
using VehicleReSell.Business.DTO.EntityDto;
using VehicleReSell.Business.DTO.ItemReceiptDto;
using VehicleReSell.Business.DTO.SaleOrderDto;
using VehicleReSell.Business.DTO.SellerDto;
using VehicleReSell.Business.DTO.StaffDto;
using VehicleReSell.Business.DTO.TransactionDto;
using VehicleReSell.Business.DTO.TransactionLineDto;
using VehicleReSell.Business.DTO.UserDto;
using VehicleReSell.Business.DTO.VehicleDto;
using VehicleReSell.Business.DTO.VehicleOwnerDto;
using VehicleReSell.Business.DTO.WareHouseDto;

namespace VehicleReSell.Business.DTO;

public static class DTOConfig
{
    public static void ConfigMapper()
    {
        IDto.Config<AssessorSView>();
        IDto.Config<CustomerSView>();
        IDto.Config<CustomerEventSView>();
        IDto.Config<EntitySView>();
        IDto.Config<ItemReceiptSView>();
        IDto.Config<SaleOrderSView>();
        IDto.Config<SellerSView>();
        IDto.Config<StaffSView>();
        IDto.Config<TransactionSView>();
        IDto.Config<LineSView>();
        IDto.Config<UserSView>();
        IDto.Config<VehicleView>();
        IDto.Config<VehicleOwnerSView>();
        IDto.Config<WareHouseView>();
        IDto.Config<CreateWareHouse>();
        IDto.Config<CreateItemReceipt>();
    }
}