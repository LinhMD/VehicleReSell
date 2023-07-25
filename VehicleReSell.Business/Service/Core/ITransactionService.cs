using CrudApiTemplate.Services;
using VehicleReSell.Business.DTO.TransactionDto;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.Service.Core;

public interface ITransactionService : IServiceCrud<Transaction>
{
    public Task<Transaction> UpdateTransactionAsync(UpdateTransaction update);
    public Task UpdateVehicleStatusAsync(int transactionId, VehicleStatus from, VehicleStatus to);

    public Task UpdateVehicleLocationAsync(int transactionId, int warehouseId);


}