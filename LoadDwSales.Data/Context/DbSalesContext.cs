

using LoadDwSales.Data.Entities.DwVentas;
using LoadDWSales.Data.Entities.DwVentas;
using Microsoft.EntityFrameworkCore;

namespace LoadDWSales.Data.Context
{
    public class DbSalesContext(DbContextOptions<DbSalesContext> options) : DbContext(options)
    {
        public DbSet<DimEmployee> DimEmployees { get; set; }
        public DbSet<DimCategory> DimCategories { get; set; }
        public DbSet<DimCustomer> DimCustomers { get; set; }
        public DbSet<DimShipper> DimShippers { get; set; }
        public DbSet<DimProduct> DimProducts { get; set; }
        public DbSet<FactCustomerAttended> FactCustomersAttended { get; set; }
        public DbSet<FactSale> FactSales { get; set; }
    }
}
