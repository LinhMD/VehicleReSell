using CrudApiTemplate.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VehicleReSell.Data.Model;

namespace VehicleReSell.Data.Repository
{
    public class VehicleReSellDbContext : DbContext
    {

        private readonly IConfiguration _config;

        public VehicleReSellDbContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                _config["ConnectionStrings:Azure_DB"],
                b => b.MigrationsAssembly("VehicleReSell.API")
                    .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                                        .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
          
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Assessor> Assessors { get; set; }
        public DbSet<TransferOrder> TransferOrders { get; set; }
        public DbSet<ItemReceipt> ItemReceipts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionLine> TransactionLines { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleOwner> VehicleOwners { get; set; }

        public DbSet<WareHouse> WareHouses { get; set; }
        public DbSet<SystemLog> SystemLogs { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerEvent> CustomerEvent { get; set; }

    }
}