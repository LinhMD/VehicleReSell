using CrudApiTemplate.Repository;

namespace VehicleReSell.Data.Repository;

public class VrsUnitOfWork : UnitOfWork
{
    private readonly VehicleReSellDbContext dataContext;

    public VrsUnitOfWork(VehicleReSellDbContext dataContext) : base(dataContext)
    {
        this.dataContext = dataContext;
    }

}