using CrudApiTemplate.Services;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.Service.Core;

public interface ITransactionService : IServiceCrud<Transaction>
{
    public Task UpdateVehicleStatusAsync(int transactionId, VehicleStatus from, VehicleStatus to);
}