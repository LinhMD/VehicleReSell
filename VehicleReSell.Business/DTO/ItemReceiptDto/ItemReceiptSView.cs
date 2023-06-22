using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using VehicleReSell.Business.DTO.AssessorDto;
using VehicleReSell.Business.DTO.StaffDto;
using VehicleReSell.Business.DTO.TransactionDto;
using VehicleReSell.Business.DTO.UserDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.ItemReceiptDto;

public class ItemReceiptSView :  IView<ItemReceipt>, IDto
{
    public int Id { get; set; }

    public TransactionSView? Transaction { get; set; }

    public StaffSView? Staff { get; set; }

    public AssessorSView? Assessor { get; set; }

    public ItemReceiptStatus ItemReceiptStatus { get; set; }

    public UserSView? Approver { get; set; }
}
