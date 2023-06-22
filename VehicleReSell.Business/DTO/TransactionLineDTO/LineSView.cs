using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.TransactionLineDto;

public class LineSView :  IView<User>, IDto
{
    public int Id { get; set; }


    public string UserName { get; set; } = string.Empty;
    public Role Role { get; set; }
}
