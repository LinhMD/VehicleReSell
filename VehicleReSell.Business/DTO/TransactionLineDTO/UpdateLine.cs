using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.DTO.TransactionLineDto;

public class UpdateLine : UpdateDto, IUpdateRequest<TransactionLine>
{
    public string? UserName { get; set; } = string.Empty;

    public Role? Role { get; set; }
}
