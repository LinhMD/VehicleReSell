using CrudApiTemplate.Repository;
using Microsoft.EntityFrameworkCore;
using VehicleReSell.Data.Repository;

public class VRSUnitOfWork : UnitOfWork
{
    private readonly VehicleReSellDbContext dataContext;

    public VRSUnitOfWork(VehicleReSellDbContext dataContext) : base(dataContext)
    {
        this.dataContext = dataContext;
    }

}