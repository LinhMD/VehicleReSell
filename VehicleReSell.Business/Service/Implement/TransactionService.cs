using CrudApiTemplate.Repository;
using CrudApiTemplate.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VehicleReSell.Business.DTO.VehicleDto;
using VehicleReSell.Business.Service.Core;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Business.Service.Implement;

public class TransactionService: ServiceCrud<Transaction>,ITransactionService
{
    private readonly IUnitOfWork _work;
    public TransactionService(IUnitOfWork work, ILogger<TransactionService> logger) : base(work, logger)
    {
        _work = work;
    }

    public async Task UpdateVehicleStatusAsync(int transactionId, VehicleStatus from, VehicleStatus to)
    {
        var vehicleIds = await _work.Get<TransactionLine>()
            .Find(line => line.TransactionId == transactionId)
            .Select(line => line.VehicleId)
            .ToListAsync();
        var vehicles = await _work.Get<Vehicle>()
            .Find(v => vehicleIds.Contains(v.Id) && v.VehicleStatus == from)
            .ToListAsync();
        vehicles.ForEach(v => v.VehicleStatus = to);
        await _work.CompleteAsync();
    }
    
}