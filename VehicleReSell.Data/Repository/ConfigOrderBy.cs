using Microsoft.Extensions.DependencyInjection;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Data.Repository;

public static class ConfigOrderBy
{
    public static void ConfigOrder(this IServiceCollection serviceCollection)
    {
        new Assessor().ConfigOrderBy();
        new Customer().ConfigOrderBy();
        new CustomerEvent().ConfigOrderBy();
        new ItemReceipt().ConfigOrderBy();
        new VehicleOwner().ConfigOrderBy();
        new SaleOrder().ConfigOrderBy();
        new Seller().ConfigOrderBy();
        new Staff().ConfigOrderBy();
        new Transaction().ConfigOrderBy();
        new TransactionLine().ConfigOrderBy();
        new TransferOrder().ConfigOrderBy();
        new User().ConfigOrderBy();
        new Vehicle().ConfigOrderBy();
        new WareHouse().ConfigOrderBy();
    }
}