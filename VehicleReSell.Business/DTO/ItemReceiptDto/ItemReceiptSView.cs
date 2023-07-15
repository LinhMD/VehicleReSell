using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using Mapster;
using VehicleReSell.Business.DTO.AssessorDto;
using VehicleReSell.Business.DTO.SellerDto;
using VehicleReSell.Business.DTO.StaffDto;
using VehicleReSell.Business.DTO.TransactionDto;
using VehicleReSell.Business.DTO.UserDto;
using VehicleReSell.Business.DTO.VehicleOwnerDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.ItemReceiptDto;

public class ItemReceiptSView :BaseModel,  IView<ItemReceipt>, IDto
{
    public int Id { get; set; }

    public TransactionSView? Transaction { get; set; }

    public StaffSView? Staff { get; set; }

    public AssessorSView? Assessor { get; set; }

    public ItemReceiptStatus ItemReceiptStatus { get; set; }

    public UserSView? Approver { get; set; }
    public string? Request { get; set; }

    public string? Img { get; set; }
    public void InitMapper()
    {
        TypeAdapterConfig<ItemReceipt, ItemReceiptSView>.NewConfig();
    }
}
